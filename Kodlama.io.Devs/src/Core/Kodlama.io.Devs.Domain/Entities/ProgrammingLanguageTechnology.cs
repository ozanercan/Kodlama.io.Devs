namespace Kodlama.io.Devs.Domain.Entities;

public class ProgrammingLanguageTechnology : Technology
{
    public int ProgrammingLanguageId { get; set; }

    public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
}
