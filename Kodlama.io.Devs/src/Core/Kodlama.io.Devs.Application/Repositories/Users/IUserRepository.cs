using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Repositories.Users;
public interface IUserRepository : IAsyncRepository<User>
{
}
