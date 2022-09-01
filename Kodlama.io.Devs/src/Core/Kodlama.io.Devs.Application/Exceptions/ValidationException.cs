namespace Kodlama.io.Devs.Application.Exceptions;

public sealed class ValidationException : ExceptionBase
{
    public ValidationException(string message) : base(message)
    {
    }
}
