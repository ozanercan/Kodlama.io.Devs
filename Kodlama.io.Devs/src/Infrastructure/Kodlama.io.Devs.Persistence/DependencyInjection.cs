using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddDbContext<EfDbContext, EfPostgreDbContext>();

        services.AddScoped<IProgrammingLanguageReadRepository, ProgrammingLanguageReadRepository>();
        services.AddScoped<IProgrammingLanguageWriteRepository, ProgrammingLanguageWriteRepository>();

        return services;
    }
}
