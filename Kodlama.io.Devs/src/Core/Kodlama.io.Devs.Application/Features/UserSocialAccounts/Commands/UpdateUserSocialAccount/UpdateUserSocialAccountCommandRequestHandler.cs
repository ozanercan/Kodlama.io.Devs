using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities.Socials;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.UserSocialPlatforms;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.UpdateUserSocialAccount;

public class UpdateUserSocialAccountCommandRequestHandler : IRequestHandler<UpdateUserSocialAccountCommandRequest, IResponse>
{
    private readonly IUserSocialAccountRepository _repository;
    private readonly IMapper _mapper;
    private readonly UserSocialAccountBusinessRules _userSocialAccountBusinessRules;
    public UpdateUserSocialAccountCommandRequestHandler(IUserSocialAccountRepository repository, IMapper mapper, UserSocialAccountBusinessRules userSocialAccountBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _userSocialAccountBusinessRules = userSocialAccountBusinessRules;
    }

    public async Task<IResponse> Handle(UpdateUserSocialAccountCommandRequest request, CancellationToken cancellationToken)
    {
        var userSocialAccount = await _repository.GetAsync(x => x.Id.Equals(request.Id));

        _userSocialAccountBusinessRules.IsShouldNotNull(userSocialAccount, Messages.UserSocialAccountIsNotFound);

        _mapper.Map<UpdateUserSocialAccountCommandRequest, UserSocialAccount>(request, userSocialAccount);

        _repository.Update(userSocialAccount);

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.UserSocialAccountIsNotUpdated);

        return new SuccessResponse(Messages.UserSocialAccountIsUpdated, HttpStatusCode.OK);
    }
}
