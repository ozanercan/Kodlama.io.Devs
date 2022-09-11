namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.SoftDeleteProgrammingLanguage;

public class SoftDeleteProgrammingLanguageCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}
