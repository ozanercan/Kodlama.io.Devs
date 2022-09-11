using FluentValidation;
using Kodlama.io.Devs.Application.Features.Users.Queries.LoginUser;

namespace Kodlama.io.Devs.Application.Features.Users.Validators;

public class LoginUserQueryRequestValidator : AbstractValidator<LoginUserQueryRequest>
{
    public LoginUserQueryRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}
