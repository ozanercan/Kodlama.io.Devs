using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyById;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Validators;

public class GetProgramingLanguageTechnologyByIdQueryRequestValidator : AbstractValidator<GetProgrammingLanguageTechnologyByIdQueryRequest>
{
    public GetProgramingLanguageTechnologyByIdQueryRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}
