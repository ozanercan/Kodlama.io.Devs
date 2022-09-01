using Kodlama.io.Devs.Application.Responses.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers.Bases;

[ApiController]
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
