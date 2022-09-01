using Kodlama.io.Devs.Domain.Commons.Base;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Repositories.Bases;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    public DbSet<TEntity> Table { get; }
}