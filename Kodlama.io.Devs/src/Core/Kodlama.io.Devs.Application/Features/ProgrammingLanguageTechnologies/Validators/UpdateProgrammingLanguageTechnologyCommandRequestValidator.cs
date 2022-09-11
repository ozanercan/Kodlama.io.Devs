using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Validators;

public class UpdateProgrammingLanguageTechnologyCommandRequestValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommandRequest>
{
    public UpdateProgrammingLanguageTechnologyCommandRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.ProgrammingLanguageId)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .MinimumLength(EntityColumnLimits.ProgrammingLanguage.NameMinLength)
            .MaximumLength(EntityColumnLimits.ProgrammingLanguage.NameMaxLength)
            .NotEmpty();
    }
}