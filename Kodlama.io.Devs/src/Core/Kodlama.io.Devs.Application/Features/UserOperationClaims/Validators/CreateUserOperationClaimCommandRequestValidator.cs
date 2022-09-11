using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Validators;

public class CreateUserOperationClaimCommandRequestValidator : AbstractValidator<CreateUserOperationClaimCommandRequest>
{
    public CreateUserOperationClaimCommandRequestValidator()
    {
        RuleFor(x => x.OperationClaims).NotNull();
        RuleFor(x => x.User).NotNull();
    }
}
