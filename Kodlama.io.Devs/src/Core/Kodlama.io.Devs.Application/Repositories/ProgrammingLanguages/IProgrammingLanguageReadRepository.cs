using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Repositories.ProgrammingLanguages;
public interface IProgrammingLanguageReadRepository : IReadRepository<ProgrammingLanguage>
{
    /// <summary>
    /// Name değerinin kayıtlı olup olmadığını kontrol eder.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ignoreId">Bu değer verilirse bu id hariç diğer kayıtlara bakacaktır.</param>
    /// <returns>Kayıt bulunursa true döner.</returns>
    Task<bool> IsThereNameAsync(string name, Guid? ignoreId = null);
}
