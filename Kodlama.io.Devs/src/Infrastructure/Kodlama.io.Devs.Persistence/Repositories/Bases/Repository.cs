using Kodlama.io.Devs.Application.Repositories.Bases;
using Kodlama.io.Devs.Domain.Commons.Base;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Repositories.Bases;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected internal readonly EfDbContext _dataContext;

    public Repository(EfDbContext dataContext)
    {
        _dataContext = dataContext;
    }

    public DbSet<TEntity> Table => _dataContext.Set<TEntity>();
}