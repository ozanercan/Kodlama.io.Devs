using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.SoftDeleteProgrammingLanguage;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Validators;

public class SoftDeleteProgrammingLanguageCommandRequestValidator : AbstractValidator<SoftDeleteProgrammingLanguageCommandRequest>
{
    public SoftDeleteProgrammingLanguageCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
