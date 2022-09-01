using System.Net;

namespace Kodlama.io.Devs.Application.Responses.Concrete;

public class SuccessDataResponse<T> : DataResponse<T>
{
    public SuccessDataResponse(string message, HttpStatusCode statusCode, T data) : base(message, true, statusCode, data)
    {
    }
}
