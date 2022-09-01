using Microsoft.AspNetCore.Http;

namespace Kodlama.io.Devs.Application.Middlewares.Exceptions;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception is BusinessException businessException)
            return context.Response.WriteAsync(businessException.ToString());

        return context.Response.WriteAsync(exception.ToString());
    }
}
