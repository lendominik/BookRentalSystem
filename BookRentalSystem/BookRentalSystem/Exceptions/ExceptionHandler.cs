using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace BookRentalSystem.Exceptions;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string errorMessage) = exception switch
        {
            NotFoundException notFoundException => (403, notFoundException.Message),
            ValidationException validationException => (400, validationException.Message),
            _ => (500, "Something went wrong.")
        };

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(errorMessage);

        return true;
    }
}
