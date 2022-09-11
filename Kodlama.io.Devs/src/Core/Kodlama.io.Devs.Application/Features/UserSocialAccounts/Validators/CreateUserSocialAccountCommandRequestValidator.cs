using FluentValidation;
using Kodlama.io.Devs.Application.Features.UserSocialAccounts.Commands.CreateUserSocialAccount;

namespace Kodlama.io.Devs.Application.Features.UserSocialAccounts.Validators;

public class CreateUserSocialAccountCommandRequestValidator : AbstractValidator<CreateUserSocialAccountCommandRequest>
{
    public CreateUserSocialAccountCommandRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.SocialPlatformId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.Path)
            .NotEmpty()
            .MinimumLength(EntityColumnLimits.UserSocialAccount.PathMinLength)
            .MaximumLength(EntityColumnLimits.UserSocialAccount.PathMaxLength);
    }
}
