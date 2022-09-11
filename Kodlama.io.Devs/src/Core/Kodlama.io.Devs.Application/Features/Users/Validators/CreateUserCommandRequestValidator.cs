using FluentValidation;
using Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;

namespace Kodlama.io.Devs.Application.Features.Users.Validators;

public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}