using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguages;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, EfPostgreDbContext>();

        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();

        return services;
    }
}
