namespace Kodlama.io.Devs.Application.Exceptions;

public sealed class BusinessException : ExceptionBase
{
    public BusinessException(string message) : base(message)
    {
    }
}