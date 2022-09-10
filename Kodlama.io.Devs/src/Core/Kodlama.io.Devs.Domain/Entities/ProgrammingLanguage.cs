using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Commons.Base;

namespace Kodlama.io.Devs.Domain.Entities;
public class ProgrammingLanguage : Entity, ICreatedDate, ISoftDeleteAudit
{
    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}
