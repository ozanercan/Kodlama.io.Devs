using Kodlama.io.Devs.Domain.Commons.Base;

namespace Kodlama.io.Devs.Application.Repositories.Bases;

public interface IWriteRepositoryWithSoftDelete<TEntity> : IWriteRepository<TEntity>
    where TEntity : class, IEntity, ISoftDelete
{
    void SoftDelete(TEntity entity);
}
