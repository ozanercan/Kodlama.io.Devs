using Core.Application.Requests;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologies;

public class GetProgrammingLanguageTechnologiesQueryRequest : PageRequest, IRequest<IDataResponse<GetProgrammingLanguageTechnologiesQueryResponse>>
{
}
