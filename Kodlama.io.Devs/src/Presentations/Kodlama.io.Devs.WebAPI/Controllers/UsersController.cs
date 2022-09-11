using Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;
using Kodlama.io.Devs.Application.Features.Users.Queries.LoginUser;
using Microsoft.AspNetCore.Authorization;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/users")]
public class UsersController : ApiControllerBase
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateUserCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginUserQueryRequest request)
        => base.GenerateResponse(await _mediator.Send(request));
}
