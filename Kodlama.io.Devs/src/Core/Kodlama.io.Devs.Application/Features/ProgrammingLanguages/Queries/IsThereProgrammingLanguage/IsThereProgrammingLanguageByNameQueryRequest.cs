namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries;

public class IsThereProgrammingLanguageByNameQueryRequest : IRequest<bool>
{
    public int? IgnoreId { get; set; }
    public string Name { get; set; }
}
