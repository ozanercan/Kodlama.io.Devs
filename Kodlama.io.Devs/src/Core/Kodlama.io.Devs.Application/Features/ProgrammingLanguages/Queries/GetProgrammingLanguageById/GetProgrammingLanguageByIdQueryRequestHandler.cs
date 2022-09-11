using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;

public class GetProgrammingLanguageByIdQueryRequestHandler : IRequestHandler<GetProgrammingLanguageByIdQueryRequest, IDataResponse<GetProgrammingLanguageByIdQueryResponse>>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

    public GetProgrammingLanguageByIdQueryRequestHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
    }

    public async Task<IDataResponse<GetProgrammingLanguageByIdQueryResponse>> Handle(GetProgrammingLanguageByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(_programmingLanguage => _programmingLanguage.Id.Equals(request.Id));

        _programmingLanguagesBusinessRules.IsShouldBeNotNull(entity);

        var responseModel = _mapper.Map<ProgrammingLanguage, GetProgrammingLanguageByIdQueryResponse>(entity);

        return new SuccessDataResponse<GetProgrammingLanguageByIdQueryResponse>(Messages.ProgrammingLanguageIsBrought, HttpStatusCode.OK, responseModel);
    }
}