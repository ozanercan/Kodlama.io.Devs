using Kodlama.io.Devs.Domain.Commons.Base;
using System.Linq.Expressions;

namespace Kodlama.io.Devs.Application.Repositories.Bases;
public interface IReadRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, bool asNoTracking = true);
    Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = true);
    Task<ICollection<TEntity>> GetAllAsync(bool asNoTracking = true);
    Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp, bool asNoTracking = true);
}
