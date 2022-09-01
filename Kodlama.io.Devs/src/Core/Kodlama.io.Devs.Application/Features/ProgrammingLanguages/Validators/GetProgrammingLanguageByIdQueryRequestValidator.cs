using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Validators;

public class GetProgrammingLanguageByIdQueryRequestValidator : AbstractValidator<GetProgrammingLanguageByIdQueryRequest>
{
    public GetProgrammingLanguageByIdQueryRequestValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
