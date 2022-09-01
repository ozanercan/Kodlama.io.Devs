using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Validators;

public class IsThereProgrammingLanguageByNameQueryRequestValidator : AbstractValidator<IsThereProgrammingLanguageByNameQueryRequest>
{
    public IsThereProgrammingLanguageByNameQueryRequestValidator()
    {
        RuleFor(_request => _request.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(_request => _request.IgnoreId);
    }
}
