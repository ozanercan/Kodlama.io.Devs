using Core.Security.Entities.Socials;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.CreateUserSocialAccount;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.SoftDeleteUserSocialAccount;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.UpdateUserSocialAccount;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Mappings;
public class UserSocialAccountMappings : Profile
{
    public UserSocialAccountMappings()
    {
        CreateMap<CreateUserSocialAccountCommandRequest, UserSocialAccount>();

        CreateMap<UpdateUserSocialAccountCommandRequest, UserSocialAccount >();

        CreateMap<SoftDeleteUserSocialAccountCommandRequest, UserSocialAccount>()
            .ForMember(x => x.IsDeleted, mopt => mopt.MapFrom(v => true));
    }
}
