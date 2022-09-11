namespace Kodlama.io.Devs.Application.Constants;
public record EntityColumnLimits
{
    public record ProgrammingLanguage
    {
        public const byte NameMinLength = 2;
        public const byte NameMaxLength = 50;
    }
    public record Technology
    {
        public const byte NameMinLength = 1;
        public const byte NameMaxLength = 50;
    }
    public record UserSocialAccount
    {
        public const byte PathMinLength = 4;
        public const byte PathMaxLength = 100;
    }
}
