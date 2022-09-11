using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.UpdateUserSocialAccount;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Validators;

public class UpdateUserSocialAccountCommandRequestValidator : AbstractValidator<UpdateUserSocialAccountCommandRequest>
{
    public UpdateUserSocialAccountCommandRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.Path)
            .NotEmpty()
            .MinimumLength(EntityColumnLimits.UserSocialAccount.PathMinLength)
            .MaximumLength(EntityColumnLimits.UserSocialAccount.PathMaxLength);
    }
}
