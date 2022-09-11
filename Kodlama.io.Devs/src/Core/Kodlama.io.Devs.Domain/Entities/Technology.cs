using Core.Persistence.Repositories;
using Core.Security._Bases;

namespace Kodlama.io.Devs.Domain.Entities;
public class Technology : EntityBase, ISoftDelete
{
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
}