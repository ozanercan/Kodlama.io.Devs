using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.SoftDeleteUserSocialAccount;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Validators;

public class SoftDeleteUserSocialAccountCommandRequestValidator : AbstractValidator<SoftDeleteUserSocialAccountCommandRequest>
{
    public SoftDeleteUserSocialAccountCommandRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
