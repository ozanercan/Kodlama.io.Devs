using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.SoftDeleteProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyById;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/programming-language-technologies")]
public class ProgrammingLanguageTechnologiesController : ApiControllerBase
{
    public ProgrammingLanguageTechnologiesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateProgrammingLanguageTechnologyCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateProgrammingLanguageTechnologyCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpDelete("soft-delete")]
    public async Task<IActionResult> SoftDeleteAsync(SoftDeleteProgrammingLanguageTechnologyCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpPut("get-by-id/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
        => base.GenerateResponse(await _mediator.Send(new GetProgrammingLanguageTechnologyByIdQueryRequest() { Id = id }));

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => base.GenerateResponse(await _mediator.Send(new GetProgrammingLanguageTechnologiesQueryRequest()));
}
