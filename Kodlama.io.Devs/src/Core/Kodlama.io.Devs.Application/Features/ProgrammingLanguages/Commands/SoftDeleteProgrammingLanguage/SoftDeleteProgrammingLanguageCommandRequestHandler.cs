using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.SoftDeleteProgrammingLanguage;

public class SoftDeleteProgrammingLanguageCommandRequestHandler : IRequestHandler<SoftDeleteProgrammingLanguageCommandRequest, IResponse>
{
    private readonly IProgrammingLanguageRepository _repository;
    public SoftDeleteProgrammingLanguageCommandRequestHandler(IProgrammingLanguageRepository writeRepository)
    {
        _repository = writeRepository;
    }

    public async Task<IResponse> Handle(SoftDeleteProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(_programmingLanguage => _programmingLanguage.Id.Equals(request.Id));

        return new SuccessResponse(Messages.ProgrammingLanguageIsDeleted, HttpStatusCode.OK);
    }
}
