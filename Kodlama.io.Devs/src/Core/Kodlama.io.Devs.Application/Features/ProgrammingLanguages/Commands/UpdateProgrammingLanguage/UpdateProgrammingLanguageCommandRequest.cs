namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandRequest : IRequest<IResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
