using Kodlama.io.Devs.Application.Constants;
using Kodlama.io.Devs.Application.Responses.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace Kodlama.io.Devs.WebAPI.Controllers.Bases;

[ApiController, Authorize(AuthenticationSchemes = ProjectSettings.AuthenticationScheme)]
public class ApiControllerBase : ControllerBase
{
    protected readonly IMediator _mediator;

    public ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    [NonAction]
    public IActionResult GenerateResponse(IResponse response)
        => new JsonResult(response) { StatusCode = (int)response.StatusCode };

    [NonAction]
    public async Task<IActionResult> GenerateResponse(Task<IResponse> response)
    {
        var newResponse = await response;
        return this.GenerateResponse(newResponse);
    }
}
