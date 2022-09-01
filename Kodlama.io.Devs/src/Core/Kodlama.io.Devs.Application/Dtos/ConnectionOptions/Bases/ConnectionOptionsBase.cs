namespace Kodlama.io.Devs.Application.Dtos.ConnectionOptions.Bases;

public abstract class ConnectionOptionsBase
{
    public abstract string ConnectionString { get; }

    public string Host { get; set; }
    public string Database { get; set; }
    public string UserId { get; set; }
    public string Password { get; set; }
}
