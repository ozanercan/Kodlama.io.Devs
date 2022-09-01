using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Repositories.Bases;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguages;
public class ProgrammingLanguageReadRepository : ReadRepository<ProgrammingLanguage>, IProgrammingLanguageReadRepository
{
    public ProgrammingLanguageReadRepository(EfDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<bool> IsThereNameAsync(string name, Guid? ignoreId = null)
    {
        var query = Table.AsQueryable();

        if (ignoreId.HasValue)
            query = query.Where(_entity => _entity.Id.Equals(ignoreId.Value) == false);

        return await query.AnyAsync(_programmingLanguage => _programmingLanguage.Name.Equals(name));
    }
}
