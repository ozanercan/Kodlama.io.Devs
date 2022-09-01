using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries;

public class IsThereProgrammingLanguageByNameQueryRequestHandler : IRequestHandler<IsThereProgrammingLanguageByNameQueryRequest, bool>
{
    private readonly IProgrammingLanguageReadRepository _readRepository;

    public IsThereProgrammingLanguageByNameQueryRequestHandler(IProgrammingLanguageReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<bool> Handle(IsThereProgrammingLanguageByNameQueryRequest request, CancellationToken cancellationToken)
        => await _readRepository.IsThereNameAsync(request.Name, request.IgnoreId);
}
