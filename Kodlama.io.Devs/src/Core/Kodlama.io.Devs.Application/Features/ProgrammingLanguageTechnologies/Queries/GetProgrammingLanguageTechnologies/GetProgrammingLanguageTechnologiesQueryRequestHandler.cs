using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologies;

public class GetProgrammingLanguageTechnologiesQueryRequestHandler : IRequestHandler<GetProgrammingLanguageTechnologiesQueryRequest, IDataResponse<GetProgrammingLanguageTechnologiesQueryResponse>>
{
    private readonly IProgrammingLanguageTechnologyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageTechnologyBusinessRules _businessRules;
    public GetProgrammingLanguageTechnologiesQueryRequestHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules businessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IDataResponse<GetProgrammingLanguageTechnologiesQueryResponse>> Handle(GetProgrammingLanguageTechnologiesQueryRequest request, CancellationToken cancellationToken)
    {
        var programmingLanguageTechnologies = await _repository.GetListAsync(include: x => x.Include(_programmingLanguageTechnology => _programmingLanguageTechnology.ProgrammingLanguage));

        _businessRules.IsAny(programmingLanguageTechnologies.Items, Messages.ProgrammingLanguageTechnologiesAreNotFound);

        var responseModel = _mapper.Map<IPaginate<ProgrammingLanguageTechnology>, GetProgrammingLanguageTechnologiesQueryResponse>(programmingLanguageTechnologies);

        return new SuccessDataResponse<GetProgrammingLanguageTechnologiesQueryResponse>(Messages.ProgrammingLanguageTechnologiesAreListed, HttpStatusCode.OK, responseModel);
    }
}
