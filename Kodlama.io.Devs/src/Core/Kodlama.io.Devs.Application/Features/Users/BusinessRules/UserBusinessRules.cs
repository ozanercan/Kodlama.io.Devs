using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Kodlama.io.Devs.Application.Features.Users.BusinessRules;
public class UserBusinessRules
{
    public void IsShouldNotNull(User user, string message)
    {
        if (user is null)
            throw new BusinessException(message);
    }

    public void PasswordIsShouldCorrect(string password, byte[] passwordHash, byte[] passwordSalt, string message)
    {
        if (HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt) is false)
            throw new BusinessException(message);
    }
}
