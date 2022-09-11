using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Kodlama.io.Devs.Application.Constants;
public static class ProjectSettings
{
    public const string AuthenticationScheme = JwtBearerDefaults.AuthenticationScheme;
    public const string DefaultPolicyName = "auth-policies";
}
