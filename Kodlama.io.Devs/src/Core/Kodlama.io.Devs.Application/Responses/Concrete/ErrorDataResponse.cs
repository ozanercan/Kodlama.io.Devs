using System.Net;

namespace Kodlama.io.Devs.Application.Responses.Concrete;

public class ErrorDataResponse<T> : DataResponse<T>
{
    public ErrorDataResponse(string message, HttpStatusCode statusCode) : base(message, false, statusCode, default)
    {
    }
    public ErrorDataResponse(string message, HttpStatusCode statusCode, T data) : base(message, false, statusCode, data)
    {
    }
}