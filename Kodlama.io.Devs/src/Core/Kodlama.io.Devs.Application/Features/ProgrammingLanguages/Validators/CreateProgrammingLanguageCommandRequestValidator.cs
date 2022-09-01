using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Validators;

public class CreateProgrammingLanguageCommandRequestValidator : AbstractValidator<CreateProgrammingLanguageCommandRequest>
{
    public CreateProgrammingLanguageCommandRequestValidator()
    {
        RuleFor(_request => _request.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(EntityColumnLimits.ProgrammingLanguageNameMinLength)
            .MaximumLength(EntityColumnLimits.ProgrammingLanguageNameMaxLength);
    }
}
