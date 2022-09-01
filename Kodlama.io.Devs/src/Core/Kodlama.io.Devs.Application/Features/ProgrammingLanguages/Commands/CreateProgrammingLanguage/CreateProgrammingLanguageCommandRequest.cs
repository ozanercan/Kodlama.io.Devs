namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandRequest : IRequest<IDataResponse<CreateProgrammingLanguageCommandResponse>>
{
    public string Name { get; set; }
}
