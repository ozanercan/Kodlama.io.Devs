using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Repositories.OperationClaims;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommandRequestHandler : IRequestHandler<CreateUserOperationClaimCommandRequest, IResponse>
{
    private readonly IUserOperationClaimRepository _repository;

    public CreateUserOperationClaimCommandRequestHandler(IUserOperationClaimRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResponse> Handle(CreateUserOperationClaimCommandRequest request, CancellationToken cancellationToken)
    {
        var userOperationClaimsToAdd = new List<UserOperationClaim>();

        foreach (var operationClaim in request.OperationClaims)
        {
            userOperationClaimsToAdd.Add(new UserOperationClaim()
            {
                User = request.User,
                OperationClaimId = (int)operationClaim
            });
        }

        await _repository.CreateBulkAsync(userOperationClaimsToAdd);

        if (request.IsSaveChanges && await _repository.SaveChangesAsync() is false)
            throw new BusinessException(Messages.UserOperationClaimsAreNotCreated);

        return new SuccessResponse(Messages.UserOperationClaimsAreCreated, HttpStatusCode.Created);
    }
}
