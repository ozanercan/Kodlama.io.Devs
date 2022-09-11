using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommandRequest : IRequest<IResponse>
{
    public User User { get; set; }
    public HashSet<OperationClaims.Enums.OperationClaims> OperationClaims { get; set; }

    public bool IsSaveChanges { get; set; }
}