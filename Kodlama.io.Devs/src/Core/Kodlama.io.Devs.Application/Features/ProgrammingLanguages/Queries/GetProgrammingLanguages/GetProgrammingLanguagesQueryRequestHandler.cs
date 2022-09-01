using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguages;

public class GetProgrammingLanguagesQueryRequestHandler : IRequestHandler<GetProgrammingLanguagesQueryRequest, IDataResponse<ICollection<GetProgrammingLanguagesQueryResponse>>>
{
    private readonly IProgrammingLanguageReadRepository _readRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

    public GetProgrammingLanguagesQueryRequestHandler(IProgrammingLanguageReadRepository readRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
    {
        _readRepository = readRepository;
        _mapper = mapper;
        _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
    }

    public async Task<IDataResponse<ICollection<GetProgrammingLanguagesQueryResponse>>> Handle(GetProgrammingLanguagesQueryRequest request, CancellationToken cancellationToken)
    {
        var programmingLanguages = await _readRepository.GetAllAsync();

        _programmingLanguagesBusinessRules.IsShouldBeAny(programmingLanguages);

        var responseModel = _mapper.Map<ICollection<ProgrammingLanguage>, ICollection<GetProgrammingLanguagesQueryResponse>>(programmingLanguages);

        return new SuccessDataResponse<ICollection<GetProgrammingLanguagesQueryResponse>>(Messages.ProgrammingLanguagesAreListed, HttpStatusCode.OK, responseModel);
    }
}
