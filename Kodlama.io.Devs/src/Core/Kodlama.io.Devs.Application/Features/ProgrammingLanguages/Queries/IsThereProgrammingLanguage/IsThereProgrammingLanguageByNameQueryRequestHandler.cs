using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries;

public class IsThereProgrammingLanguageByNameQueryRequestHandler : IRequestHandler<IsThereProgrammingLanguageByNameQueryRequest, bool>
{
    private readonly IProgrammingLanguageRepository _repository;

    public IsThereProgrammingLanguageByNameQueryRequestHandler(IProgrammingLanguageRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IsThereProgrammingLanguageByNameQueryRequest request, CancellationToken cancellationToken)
        => await _repository.AnyAsync(x => x.Name.Equals(request.Name) && x.Id.Equals(request.IgnoreId) == false);
}
