namespace Lumen.Profile.RestApi.Common.Middlewares;

public sealed class ExceptionHandlerMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        throw new NotImplementedException();
    }
}
