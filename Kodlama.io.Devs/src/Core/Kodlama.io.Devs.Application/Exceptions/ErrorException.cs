namespace Kodlama.io.Devs.Application.Exceptions;

public sealed class ErrorException : ExceptionBase
{
    public ErrorException(string message) : base(message)
    {
    }
}
