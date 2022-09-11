using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities.Socials;
using Kodlama.io.Devs.Application.Repositories.UserSocialPlatforms;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.CreateUserSocialAccount;

public class CreateUserSocialPlatformCommandRequestHandler : IRequestHandler<CreateUserSocialAccountCommandRequest, IResponse>
{
    private readonly IUserSocialAccountRepository _repository;
    private readonly IMapper _mapper;

    public CreateUserSocialPlatformCommandRequestHandler(IUserSocialAccountRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IResponse> Handle(CreateUserSocialAccountCommandRequest request, CancellationToken cancellationToken)
    {
        var userSocialAccount = _mapper.Map<CreateUserSocialAccountCommandRequest, UserSocialAccount>(request);

        await _repository.CreateAsync(userSocialAccount);

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.UserSocialAccountIsNotCreated);

        return new SuccessResponse(Messages.UserSocialAccountIsCreated, HttpStatusCode.Created);
    }
}

