using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.SoftDeleteProgrammingLanguageTechnology;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Validators;

public class SoftDeleteProgrammingLanguageTechnologyCommandRequestValidator : AbstractValidator<SoftDeleteProgrammingLanguageTechnologyCommandRequest>
{
    public SoftDeleteProgrammingLanguageTechnologyCommandRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull();
    }
}