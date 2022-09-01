using Kodlama.io.Devs.Application.Repositories.Bases;
using Kodlama.io.Devs.Domain.Commons.Base;

namespace Kodlama.io.Devs.Persistence.Repositories.Bases;

public class WriteRepository<TEntity> : Repository<TEntity>, IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    public WriteRepository(EfDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
        return entity;
    }

    public void HardDelete(TEntity entity)
        => Table.Remove(entity);

    public void HardDeleteBulk(IEnumerable<TEntity> entities)
        => Table.RemoveRange(entities);

    public async Task<bool> SaveChangesAsync()
        => await _dataContext.SaveChangesAsync() > 0;

    public void Update(TEntity entity)
        => _dataContext.Update(entity);

    public void UpdateBulk(IEnumerable<TEntity> entities)
        => _dataContext.UpdateRange(entities);
}
