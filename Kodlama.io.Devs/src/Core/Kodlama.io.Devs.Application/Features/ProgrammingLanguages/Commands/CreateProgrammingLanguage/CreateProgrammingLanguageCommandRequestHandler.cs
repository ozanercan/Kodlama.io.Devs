using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandRequestHandler : IRequestHandler<CreateProgrammingLanguageCommandRequest, IDataResponse<CreateProgrammingLanguageCommandResponse>>
{
    private readonly IProgrammingLanguageRepository _writeRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
    public CreateProgrammingLanguageCommandRequestHandler(IProgrammingLanguageRepository writeRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
    }

    public async Task<IDataResponse<CreateProgrammingLanguageCommandResponse>> Handle(CreateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
    {
        await _programmingLanguagesBusinessRules.DatabaseShouldNotHaveProgrammingLanguageNameAsync(request.Name);

        var programingLanguageToAdd = _mapper.Map<CreateProgrammingLanguageCommandRequest, ProgrammingLanguage>(request);

        await _writeRepository.CreateAsync(programingLanguageToAdd);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.ProgrammingLanguageIsNotCreated);

        var response = _mapper.Map<ProgrammingLanguage, CreateProgrammingLanguageCommandResponse>(programingLanguageToAdd);

        return new SuccessDataResponse<CreateProgrammingLanguageCommandResponse>(Messages.ProgrammingLanguageIsCreated, HttpStatusCode.Created, response);
    }
}
