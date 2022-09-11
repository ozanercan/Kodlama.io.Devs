using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities.Socials;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.BusinessRules;
public class UserSocialAccountBusinessRules
{
    public void IsShouldNotNull(UserSocialAccount entity, string message)
    {
        if (entity is null)
            throw new BusinessException(message);
    }
}
