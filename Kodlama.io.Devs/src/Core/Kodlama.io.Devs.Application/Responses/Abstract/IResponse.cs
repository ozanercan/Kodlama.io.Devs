using System.Net;

namespace Kodlama.io.Devs.Application.Responses.Abstract;

public interface IResponse
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
