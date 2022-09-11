using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Repositories.Users;
public class UserRepository : EfRepositoryBase<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}
