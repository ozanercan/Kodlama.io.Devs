namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;

public class GetProgrammingLanguageByIdQueryRequest : IRequest<IDataResponse<GetProgrammingLanguageByIdQueryResponse>>
{
    public Guid Id { get; set; }
}
