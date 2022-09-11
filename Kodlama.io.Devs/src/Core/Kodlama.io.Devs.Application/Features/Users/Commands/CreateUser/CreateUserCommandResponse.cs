using Core.Security.Dtos;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandResponse 
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
