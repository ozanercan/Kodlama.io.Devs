using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandRequestHandler : IRequestHandler<UpdateProgrammingLanguageCommandRequest, IResponse>
{
    private readonly IProgrammingLanguageWriteRepository _writeRepository;
    private readonly IProgrammingLanguageReadRepository _readRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

    public UpdateProgrammingLanguageCommandRequestHandler(IProgrammingLanguageWriteRepository writeRepository, IProgrammingLanguageReadRepository readRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mapper = mapper;
        _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
    }

    public async Task<IResponse> Handle(UpdateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _readRepository.GetByIdAsync(request.Id, asNoTracking: false);

        _programmingLanguagesBusinessRules.IsShouldBeNotNull(entity);

        await _programmingLanguagesBusinessRules.DatabaseShouldNotHaveProgrammingLanguageNameAsync(request.Name, request.Id);

        _mapper.Map<UpdateProgrammingLanguageCommandRequest, ProgrammingLanguage>(request, entity);

        _writeRepository.Update(entity);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(Messages.ProgrammingLanguageIsNotUpdated);

        return new SuccessResponse(Messages.ProgrammingLanguageIsUpdated, HttpStatusCode.OK);
    }
}
