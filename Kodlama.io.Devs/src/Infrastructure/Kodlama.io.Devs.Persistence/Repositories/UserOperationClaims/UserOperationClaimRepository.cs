using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Repositories.OperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Repositories.UserOperationClaims;
public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(DbContext context) : base(context)
    {
    }
}
