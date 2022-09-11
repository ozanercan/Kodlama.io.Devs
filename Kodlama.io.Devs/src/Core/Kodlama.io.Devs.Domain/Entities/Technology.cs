using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Commons.Base;

namespace Kodlama.io.Devs.Domain.Entities;
public class Technology : EntityBase, ISoftDelete
{
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
}