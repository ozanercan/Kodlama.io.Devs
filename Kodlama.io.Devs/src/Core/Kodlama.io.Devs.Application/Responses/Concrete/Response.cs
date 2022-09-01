using Kodlama.io.Devs.Application.Responses.Abstract;
using System.Net;

namespace Kodlama.io.Devs.Application.Responses.Concrete;

public class Response : IResponse
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public Response(string message, bool isSuccess, HttpStatusCode statusCode)
    {
        Message = message;
        IsSuccess = isSuccess;
        StatusCode = statusCode;
    }
}
