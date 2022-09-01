using Kodlama.io.Devs.Application.Responses.Abstract;
using System.Net;

namespace Kodlama.io.Devs.Application.Responses.Concrete;

public class DataResponse<T> : Response, IDataResponse<T>
{
    public T Data { get; set; }

    public DataResponse(string message, bool isSuccess, HttpStatusCode statusCode, T data) : base(message, isSuccess, statusCode)
    {
        Data = data;
    }
}
