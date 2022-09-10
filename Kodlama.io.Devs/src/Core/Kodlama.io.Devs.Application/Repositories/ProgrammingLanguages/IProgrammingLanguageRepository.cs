using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;

public interface IProgrammingLanguageRepository : IAsyncRepository<ProgrammingLanguage>
{
    Task<bool> IsThereNameAsync(string name, Guid? ignoreId = null);
}
