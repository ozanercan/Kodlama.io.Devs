using System.Net;

namespace Kodlama.io.Devs.Application.Responses.Concrete;

public class ErrorResponse : Response
{
    public ErrorResponse(string message, HttpStatusCode statusCode) : base(message, false, statusCode)
    {
    }
}
