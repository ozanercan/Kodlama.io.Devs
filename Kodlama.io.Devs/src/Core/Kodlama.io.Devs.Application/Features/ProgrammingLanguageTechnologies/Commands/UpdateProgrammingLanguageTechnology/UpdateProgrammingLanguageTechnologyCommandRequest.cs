namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;

public class UpdateProgrammingLanguageTechnologyCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
}
