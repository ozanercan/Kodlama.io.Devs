namespace Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandRequest : IRequest<IDataResponse<CreateUserCommandResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
