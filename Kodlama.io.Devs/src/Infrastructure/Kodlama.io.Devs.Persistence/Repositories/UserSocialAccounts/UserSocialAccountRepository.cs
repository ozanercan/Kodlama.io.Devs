using Core.Persistence.Repositories;
using Core.Security.Entities.Socials;
using Kodlama.io.Devs.Application.Repositories.UserSocialPlatforms;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Repositories.UserSocialAccounts;
public class UserSocialAccountRepository : EfRepositoryBase<UserSocialAccount>, IUserSocialAccountRepository
{
    public UserSocialAccountRepository(DbContext context) : base(context)
    {
    }
}
