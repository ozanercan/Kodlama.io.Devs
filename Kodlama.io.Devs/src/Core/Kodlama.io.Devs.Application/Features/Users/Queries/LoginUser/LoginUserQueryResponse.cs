using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Features.Users.Queries.LoginUser;

public class LoginUserQueryResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public AccessToken AccessToken { get; set; }
    public Core.Security.JWT.RefreshToken RefreshToken { get; set; }
}
