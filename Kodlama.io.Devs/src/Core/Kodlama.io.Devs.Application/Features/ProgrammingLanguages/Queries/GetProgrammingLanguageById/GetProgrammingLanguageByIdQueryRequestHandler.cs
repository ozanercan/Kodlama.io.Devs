using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;

public class GetProgrammingLanguageByIdQueryRequestHandler : IRequestHandler<GetProgrammingLanguageByIdQueryRequest, IDataResponse<GetProgrammingLanguageByIdQueryResponse>>
{
    private readonly IProgrammingLanguageReadRepository _readRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

    public GetProgrammingLanguageByIdQueryRequestHandler(IProgrammingLanguageReadRepository readRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
    {
        _readRepository = readRepository;
        _mapper = mapper;
        _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
    }

    public async Task<IDataResponse<GetProgrammingLanguageByIdQueryResponse>> Handle(GetProgrammingLanguageByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await _readRepository.GetByIdAsync(request.Id);

        _programmingLanguagesBusinessRules.IsShouldBeNotNull(entity);

        var responseModel = _mapper.Map<ProgrammingLanguage, GetProgrammingLanguageByIdQueryResponse>(entity);

        return new SuccessDataResponse<GetProgrammingLanguageByIdQueryResponse>(Messages.ProgrammingLanguageIsBrought, HttpStatusCode.OK, responseModel);
    }
}