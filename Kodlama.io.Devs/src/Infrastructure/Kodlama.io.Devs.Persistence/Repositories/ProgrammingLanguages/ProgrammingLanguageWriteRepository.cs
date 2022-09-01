using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Repositories.Bases;

namespace Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguages;

public class ProgrammingLanguageWriteRepository : WriteRepositoryWithSoftDelete<ProgrammingLanguage>, IProgrammingLanguageWriteRepository
{
    public ProgrammingLanguageWriteRepository(EfDbContext dataContext) : base(dataContext)
    {
    }
}
