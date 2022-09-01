using Newtonsoft.Json;

namespace Kodlama.io.Devs.Application.Exceptions;

public abstract class ExceptionBase : Exception
{
    public string Message { get; }

    public ExceptionBase(string message)
    {
        Message = message;
    }

    public override string ToString()
       => JsonConvert.SerializeObject(this);
}
