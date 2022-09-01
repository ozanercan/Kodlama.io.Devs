using Kodlama.io.Devs.Application.Repositories.Bases;
using Kodlama.io.Devs.Domain.Commons.Base;

namespace Kodlama.io.Devs.Persistence.Repositories.Bases;

public class WriteRepositoryWithSoftDelete<TEntity> : WriteRepository<TEntity>, IWriteRepositoryWithSoftDelete<TEntity>
    where TEntity : class, IEntity, ISoftDelete
{
    public WriteRepositoryWithSoftDelete(EfDbContext dataContext) : base(dataContext)
    {
    }

    public void SoftDelete(TEntity entity)
    {
        if (entity is IDeletedDate deletedDateEntity)
            deletedDateEntity.DeletedDate = DateTime.UtcNow;

        entity.IsDeleted = true;

        base.Update(entity);
    }
}
