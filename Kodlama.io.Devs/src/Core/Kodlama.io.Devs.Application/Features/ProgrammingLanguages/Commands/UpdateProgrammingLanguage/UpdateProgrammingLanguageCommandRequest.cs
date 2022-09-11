namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
