namespace Kodlama.io.Devs.Application.Responses.Abstract;

public interface IDataResponse<T> : IResponse
{
    public T Data { get; set; }
}
