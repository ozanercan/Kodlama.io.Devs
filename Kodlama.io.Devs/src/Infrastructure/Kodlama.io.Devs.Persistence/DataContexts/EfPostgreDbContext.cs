using Kodlama.io.Devs.Application.Dtos.ConnectionOptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kodlama.io.Devs.Persistence.DataContexts;

public sealed class EfPostgreDbContext : EfDbContext
{
    private readonly PostgreSqlConnectionOptions _postgreSqlConnectionOptions;
    public EfPostgreDbContext(IOptions<PostgreSqlConnectionOptions> postgreSqlConnectionOptions)
    {
        _postgreSqlConnectionOptions = postgreSqlConnectionOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_postgreSqlConnectionOptions.ConnectionString, opt =>
        {
            opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        });

        base.OnConfiguring(optionsBuilder);
    }
}
