using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Repositories.RefreshTokens;
public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken>
{
}
