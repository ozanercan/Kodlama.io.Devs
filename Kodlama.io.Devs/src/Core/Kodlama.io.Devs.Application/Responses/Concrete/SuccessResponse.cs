using System.Net;

namespace Kodlama.io.Devs.Application.Responses.Concrete;

public class SuccessResponse : Response
{
    public SuccessResponse(string message, HttpStatusCode statusCode) : base(message, true, statusCode)
    {
    }
}
