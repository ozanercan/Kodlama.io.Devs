using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Validators;

public class CreateProgrammingLanguageTechnologyCommandRequestValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommandRequest>
{
    public CreateProgrammingLanguageTechnologyCommandRequestValidator()
    {
        RuleFor(x => x.ProgrammingLanguageId)
            .GreaterThan(0);

        RuleFor(x => x.TechnologyName)
            .NotEmpty();
    }
}
