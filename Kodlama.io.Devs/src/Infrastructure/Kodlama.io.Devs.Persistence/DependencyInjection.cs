using Kodlama.io.Devs.Application.Repositories.OperationClaims;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Application.Repositories.RefreshTokens;
using Kodlama.io.Devs.Application.Repositories.Users;
using Kodlama.io.Devs.Application.Repositories.UserSocialPlatforms;
using Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Persistence.Repositories.RefreshTokens;
using Kodlama.io.Devs.Persistence.Repositories.UserOperationClaims;
using Kodlama.io.Devs.Persistence.Repositories.Users;
using Kodlama.io.Devs.Persistence.Repositories.UserSocialAccounts;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, EfPostgreDbContext>();

        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        services.AddScoped<IProgrammingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IUserSocialAccountRepository, UserSocialAccountRepository>();

        return services;
    }
}
