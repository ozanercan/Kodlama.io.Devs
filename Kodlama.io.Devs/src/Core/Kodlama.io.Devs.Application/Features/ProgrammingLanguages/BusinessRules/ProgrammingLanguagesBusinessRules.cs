using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
public class ProgrammingLanguagesBusinessRules
{
    private readonly IMediator _mediator;

    public ProgrammingLanguagesBusinessRules(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// Progralama dili adı'nın db'de olup olmadığını sorgular.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ignoreId">Bu değer update işleri için kullanılabilir. Id değeri verilirse o kayıt hariç diğer kayıtları göz önünde bulundurur.</param>
    /// <returns>Dbde varsa Exception döndürür.</returns>
    /// <exception cref="BusinessException"></exception>
    /// <summary>
    public async Task DatabaseShouldNotHaveProgrammingLanguageNameAsync(string name, Guid? ignoreId = null)
    {
        var isThereResult = await _mediator.Send(new IsThereProgrammingLanguageByNameQueryRequest()
        {
            Name = name,
            IgnoreId = ignoreId
        });

        if (isThereResult is false)
            return;

        throw new BusinessException(Messages.ProgrammingLanguageIsAlreadyExist);
    }

    public void IsShouldBeNotNull(ProgrammingLanguage programmingLanguage)
    {
        if (programmingLanguage is not null)
            return;

        throw new BusinessException(Messages.ProgrammingLanguageIsNotFound);
    }

    public void IsShouldBeAny(ICollection<ProgrammingLanguage> programmingLanguages)
    {
        if (programmingLanguages.Any())
            return;

        throw new BusinessException(Messages.ProgrammingLanguagesAreNotEmpty);
    }
}
