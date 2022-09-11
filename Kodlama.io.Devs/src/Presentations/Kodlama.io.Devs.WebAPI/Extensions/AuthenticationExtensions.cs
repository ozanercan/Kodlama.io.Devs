using Core.Security.Encryption;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Constants;
using Microsoft.IdentityModel.Tokens;

namespace Kodlama.io.Devs.WebAPI.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection service, ConfigurationManager configurationManager)
    {
        var tokenConfigurations = new TokenOptions();

        configurationManager.Bind("TokenOptions", tokenConfigurations);

        service.AddAuthentication(ProjectSettings.AuthenticationScheme).AddJwtBearer(ProjectSettings.AuthenticationScheme, opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudience = tokenConfigurations.Audience,
                ValidIssuer = tokenConfigurations.Issuer,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenConfigurations.SecurityKey),
            };
        });

        return service;
    }
}
