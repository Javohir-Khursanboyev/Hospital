using Hospital.WebApi.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace Hospital.WebApi.Middlewares
{
    public class InternalServerExceptionMiddleware : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = exception.Message,
                Data = exception.Data,
            });

            return true;
        }
    }
}
