using Core.Security._Bases;

namespace Kodlama.io.Devs.Domain.Commons.Base;

public interface ISoftDeleteAudit : ISoftDelete, IDeletedDate
{
}