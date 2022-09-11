using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities.Socials;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.UserSocialPlatforms;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.SoftDeleteUserSocialAccount;

public class SoftDeleteUserSocialAccountCommandRequestHandler : IRequestHandler<SoftDeleteUserSocialAccountCommandRequest, IResponse>
{
    private readonly IUserSocialAccountRepository _repository;
    private readonly IMapper _mapper;
    private readonly UserSocialAccountBusinessRules _userSocialAccountBusinessRules;

    public SoftDeleteUserSocialAccountCommandRequestHandler(IUserSocialAccountRepository repository, IMapper mapper, UserSocialAccountBusinessRules userSocialAccountBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _userSocialAccountBusinessRules = userSocialAccountBusinessRules;
    }

    public async Task<IResponse> Handle(SoftDeleteUserSocialAccountCommandRequest request, CancellationToken cancellationToken)
    {
        var userSocialAccount = await _repository.GetAsync(x => x.Id.Equals(request.Id));

        _userSocialAccountBusinessRules.IsShouldNotNull(userSocialAccount, Messages.UserSocialAccountIsNotFound);

        _mapper.Map<SoftDeleteUserSocialAccountCommandRequest, UserSocialAccount>(request, userSocialAccount);

        _repository.Update(userSocialAccount);

        if (await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.UserSocialAccountIsNotDeleted);

        return new SuccessResponse(Messages.UserSocialAccountIsDeleted, HttpStatusCode.OK);
    }
}
