using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;

namespace Kodlama.io.Devs.Application.Features.Users.Mappings;
public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<CreateUserCommandRequest, User>().ForMember(x => x.Status, mopt => mopt.MapFrom(v => true));
        CreateMap<User, CreateUserCommandResponse>();
    }
}
