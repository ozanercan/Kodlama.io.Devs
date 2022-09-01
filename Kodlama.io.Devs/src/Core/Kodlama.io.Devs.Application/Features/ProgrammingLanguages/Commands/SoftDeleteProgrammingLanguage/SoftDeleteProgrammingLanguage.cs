namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.SoftDeleteProgrammingLanguage;

public class SoftDeleteProgrammingLanguageCommandRequest : IRequest<IResponse>
{
    public Guid Id { get; set; }
}
