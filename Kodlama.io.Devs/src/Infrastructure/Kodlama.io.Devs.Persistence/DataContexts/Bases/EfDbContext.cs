using Kodlama.io.Devs.Domain.Commons.Base;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kodlama.io.Devs.Persistence.DataContexts.Bases;

public abstract class EfDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var proccessableEntityStates = new HashSet<EntityState>() { EntityState.Added };

        var entries = base.ChangeTracker.Entries().Where(_entry => proccessableEntityStates.Contains(_entry.State));

        foreach (var entry in entries)
        {
            if (entry.Entity is ICreatedDate entity)
                entity.CreatedDate = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<Technology> Technology { get; set; }
    public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
}
