using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.BusinessRules;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyById;

public class GetProgrammingLanguageTechnologyByIdQueryRequestHandler : IRequestHandler<GetProgrammingLanguageTechnologyByIdQueryRequest, IDataResponse<ProgrammingLanguageTechnologyDto>>
{
    private readonly IProgrammingLanguageTechnologyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageTechnologyBusinessRules _businessRules;
    public GetProgrammingLanguageTechnologyByIdQueryRequestHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules businessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IDataResponse<ProgrammingLanguageTechnologyDto>> Handle(GetProgrammingLanguageTechnologyByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var programmingLanguageTechnologies = await _repository.GetAsync(x => x.Id.Equals(request.Id), include: x => x.Include(_programmingLanguageTechnology => _programmingLanguageTechnology.ProgrammingLanguage));

        _businessRules.IsNotNull(programmingLanguageTechnologies, Messages.ProgrammingLanguageTechnologyIsNotFound);

        var responseModel = _mapper.Map<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyDto>(programmingLanguageTechnologies);

        return new SuccessDataResponse<ProgrammingLanguageTechnologyDto>(Messages.ProgrammingLanguageTechnologyIsBrought, HttpStatusCode.OK, responseModel);
    }
}
