using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyById;

public class GetProgrammingLanguageTechnologyByIdQueryRequest : IRequest<IDataResponse<ProgrammingLanguageTechnologyDto>>
{
    public int Id { get; set; }
}
