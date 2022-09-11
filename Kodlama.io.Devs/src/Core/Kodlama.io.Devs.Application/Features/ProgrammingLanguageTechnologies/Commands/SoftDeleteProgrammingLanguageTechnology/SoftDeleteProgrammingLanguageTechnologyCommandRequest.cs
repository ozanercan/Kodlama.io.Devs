namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.SoftDeleteProgrammingLanguageTechnology;

public class SoftDeleteProgrammingLanguageTechnologyCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}
