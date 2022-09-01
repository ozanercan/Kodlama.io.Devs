using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.SoftDeleteProgrammingLanguage;

public class SoftDeleteProgrammingLanguageCommandRequestHandler : IRequestHandler<SoftDeleteProgrammingLanguageCommandRequest, IResponse>
{
    private readonly IProgrammingLanguageWriteRepository _writeRepository;
    private readonly IProgrammingLanguageReadRepository _readRepository;
    public SoftDeleteProgrammingLanguageCommandRequestHandler(IProgrammingLanguageWriteRepository writeRepository, IProgrammingLanguageReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<IResponse> Handle(SoftDeleteProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _readRepository.GetAsync(_programmingLanguage => _programmingLanguage.Id.Equals(request.Id));

        _writeRepository.SoftDelete(entity);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(Messages.ProgrammingLanguageIsNotDeleted);

        return new SuccessResponse(Messages.ProgrammingLanguageIsDeleted, HttpStatusCode.OK);
    }
}
