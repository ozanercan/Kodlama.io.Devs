using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.SoftDeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguages;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/programming-languages")]
public class ProgrammingLanguagesController : ApiControllerBase
{
    public ProgrammingLanguagesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateProgrammingLanguageCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateProgrammingLanguageCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpDelete("soft-delete")]
    public async Task<IActionResult> SoftDeleteAsync(SoftDeleteProgrammingLanguageCommandRequest request)
        => base.GenerateResponse(await _mediator.Send(request));

    [HttpPut("get-by-id/{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
        => base.GenerateResponse(await _mediator.Send(new GetProgrammingLanguageByIdQueryRequest() { Id = id }));

    [HttpPut("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => base.GenerateResponse(await _mediator.Send(new GetProgrammingLanguagesQueryRequest()));
}
