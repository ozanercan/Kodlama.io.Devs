using Core.Security.Dtos;

namespace Kodlama.io.Devs.Application.Features.Users.Queries.LoginUser;

public class LoginUserQueryRequest : UserForLoginDto, IRequest<IDataResponse<LoginUserQueryResponse>>
{
}
