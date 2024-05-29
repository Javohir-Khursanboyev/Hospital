using Hospital.Service.Exceptions;
using Hospital.WebApi.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace Hospital.WebApi.Middlewares
{
    public class NotFoundExceptionMiddleware : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotFoundException ex)
                return false;

            httpContext.Response.StatusCode = ex.StatusCode;

            await httpContext.Response.WriteAsJsonAsync(new Response
            {
                Message = ex.Message,
                StatusCode = ex.StatusCode,
                Data = ex.Data
            });

            return true;
        }
    }
}
