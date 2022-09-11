using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Repositories.Users;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandRequestHandler : IRequestHandler<CreateUserCommandRequest, IDataResponse<CreateUserCommandResponse>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public CreateUserCommandRequestHandler(IUserRepository repository, IMapper mapper, IMediator mediator)
    {
        _repository = repository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IDataResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var userToAdd = _mapper.Map<CreateUserCommandRequest, User>(request);

        HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        this.MapPasswordHashingsToUser(userToAdd, passwordHash, passwordSalt);

        await _repository.CreateAsync(userToAdd);
        
        await AddRoleToUserAsync(userToAdd);

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.UserIsNotCreated);

        var responseModel = _mapper.Map<User, CreateUserCommandResponse>(userToAdd);

        return new SuccessDataResponse<CreateUserCommandResponse>(Messages.UserIsCreated, HttpStatusCode.Created, responseModel);
    }

    private async Task AddRoleToUserAsync(User userToAdd)
    {
        await _mediator.Send(new CreateUserOperationClaimCommandRequest()
        {
            User = userToAdd,
            OperationClaims = new HashSet<OperationClaims.Enums.OperationClaims>() { OperationClaims.Enums.OperationClaims.User }
        });
    }

    private void MapPasswordHashingsToUser(User user, byte[] passwordHash, byte[] passwordSalt)
    {
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
    }
}
