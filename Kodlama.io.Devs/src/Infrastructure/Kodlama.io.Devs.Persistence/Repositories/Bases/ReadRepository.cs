using Kodlama.io.Devs.Application.Repositories.Bases;
using Kodlama.io.Devs.Domain.Commons.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kodlama.io.Devs.Persistence.Repositories.Bases;
public class ReadRepository<TEntity> : Repository<TEntity>, IReadRepository<TEntity>
    where TEntity : class, IEntity
{
    public ReadRepository(EfDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<ICollection<TEntity>> GetAllAsync(bool asNoTracking = true)
    {
        var query = Table.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp, bool asNoTracking = true)
    {
        var query = Table.Where(exp);

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, bool asNoTracking = true)
    {
        var query = Table.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(exp);
    }

    public async Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        var query = Table.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync(_entity => _entity.Id.Equals(id));
    }
}
