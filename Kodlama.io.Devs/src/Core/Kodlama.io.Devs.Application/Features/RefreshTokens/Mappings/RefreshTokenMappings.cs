namespace Kodlama.io.Devs.Application.Features.RefreshTokens.Mappings;
internal class RefreshTokenMappings : Profile
{
    public RefreshTokenMappings()
    {
        CreateMap<Core.Security.Entities.RefreshToken, Core.Security.JWT.RefreshToken>().ForMember(x => x.Expiration, mopt => mopt.MapFrom(v => v.Expires));
    }
}
