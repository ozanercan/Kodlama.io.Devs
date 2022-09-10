using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguages;
public class ProgrammingLanguageRepository : Core.Persistence.Repositories.EfRepositoryBase<ProgrammingLanguage>, IProgrammingLanguageRepository
{

    public async Task<bool> IsThereNameAsync(string name, Guid? ignoreId = null)
    {
        return await base.AnyAsync(_programmingLanguage => (ignoreId.HasValue ? _programmingLanguage.Id.Equals(ignoreId.Value) : true) && _programmingLanguage.Name.Equals(name));
    }
    public ProgrammingLanguageRepository(DbContext context) : base(context)
    {
    }
}
