using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguageTechnologies;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, EfPostgreDbContext>();

        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        services.AddScoped<IProgrammingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRepository>();

        return services;
    }
}
