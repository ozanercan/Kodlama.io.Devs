using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Validators;

public class UpdateProgrammingLanguageCommandRequestValidator : AbstractValidator<UpdateProgrammingLanguageCommandRequest>
{
    public UpdateProgrammingLanguageCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(_request => _request.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(EntityColumnLimits.ProgrammingLanguageNameMinLength)
            .MaximumLength(EntityColumnLimits.ProgrammingLanguageNameMaxLength);
    }
}