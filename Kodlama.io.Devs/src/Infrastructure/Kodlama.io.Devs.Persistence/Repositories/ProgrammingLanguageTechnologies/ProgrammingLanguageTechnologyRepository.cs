using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Repositories.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Repositories.ProgrammingLanguageTechnologies;
public class ProgrammingLanguageTechnologyRepository : EfRepositoryBase<ProgrammingLanguageTechnology>, IProgrammingLanguageTechnologyRepository
{
    public ProgrammingLanguageTechnologyRepository(DbContext context) : base(context)
    {
    }
}
