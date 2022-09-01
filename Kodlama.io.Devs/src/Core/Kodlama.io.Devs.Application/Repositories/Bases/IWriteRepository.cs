using Kodlama.io.Devs.Domain.Commons.Base;

namespace Kodlama.io.Devs.Application.Repositories.Bases;

public interface IWriteRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<TEntity> CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void UpdateBulk(IEnumerable<TEntity> entities);
    void HardDelete(TEntity entity);
    void HardDeleteBulk(IEnumerable<TEntity> entities);

    Task<bool> SaveChangesAsync();
}
