using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.CreateUserSocialAccount;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.SoftDeleteUserSocialAccount;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.UpdateUserSocialAccount;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/user-social-accounts")]
public class UserSocialAccountsController : ApiControllerBase
{
    public UserSocialAccountsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateUserSocialAccountCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateUserSocialAccountCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpDelete("soft-delete")]
    public async Task<IActionResult> SoftDeleteAsync(SoftDeleteUserSocialAccountCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));
}
