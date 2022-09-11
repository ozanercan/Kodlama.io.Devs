using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguages;

public class GetProgrammingLanguagesQueryRequestHandler : IRequestHandler<GetProgrammingLanguagesQueryRequest, IDataResponse<ICollection<GetProgrammingLanguagesQueryResponse>>>
{
    private readonly IProgrammingLanguageRepository _repository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

    public GetProgrammingLanguagesQueryRequestHandler(IProgrammingLanguageRepository repository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
    }

    public async Task<IDataResponse<ICollection<GetProgrammingLanguagesQueryResponse>>> Handle(GetProgrammingLanguagesQueryRequest request, CancellationToken cancellationToken)
    {
        var programmingLanguages = await _repository.GetListAsync();

        _programmingLanguagesBusinessRules.IsShouldBeAny(programmingLanguages.Items);

        var responseModel = _mapper.Map<ICollection<ProgrammingLanguage>, ICollection<GetProgrammingLanguagesQueryResponse>>(programmingLanguages.Items);

        return new SuccessDataResponse<ICollection<GetProgrammingLanguagesQueryResponse>>(Messages.ProgrammingLanguagesAreListed, HttpStatusCode.OK, responseModel);
    }
}
