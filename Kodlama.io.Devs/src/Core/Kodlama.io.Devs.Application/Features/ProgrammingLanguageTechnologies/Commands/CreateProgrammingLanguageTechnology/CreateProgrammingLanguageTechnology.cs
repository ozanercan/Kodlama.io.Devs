using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;

public class CreateProgrammingLanguageTechnologyCommandRequest : IRequest<IDataResponse<CreateProgrammingLanguageTechnologyCommandResponse>>
{
    public int ProgrammingLanguageId { get; set; }
    public string TechnologyName { get; set; }
}
