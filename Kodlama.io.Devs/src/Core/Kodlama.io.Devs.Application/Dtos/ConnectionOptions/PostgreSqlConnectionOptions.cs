using Kodlama.io.Devs.Application.Dtos.ConnectionOptions.Bases;

namespace Kodlama.io.Devs.Application.Dtos.ConnectionOptions;

public sealed class PostgreSqlConnectionOptions : ConnectionOptionsBase
{
    public override string ConnectionString => $"Host={base.Host}; Database={base.Database}; UserId={base.UserId}; Password={base.Password}";
}
