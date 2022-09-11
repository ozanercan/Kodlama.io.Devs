using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.BusinessRules;
public class ProgrammingLanguageTechnologyBusinessRules
{
    private readonly IProgrammingLanguageTechnologyRepository _repository;

    public ProgrammingLanguageTechnologyBusinessRules(IProgrammingLanguageTechnologyRepository repository)
    {
        _repository = repository;
    }

    public void IsNotNull(ProgrammingLanguageTechnology entity, string message)
    {
        if (entity is null)
            throw new BusinessException(message);
    }

    public void IsAny(IEnumerable<ProgrammingLanguageTechnology> items, string message)
    {
        if (items.Any() is false)
            throw new BusinessException(message);
    }
}
