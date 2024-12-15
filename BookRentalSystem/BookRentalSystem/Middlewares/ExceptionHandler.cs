﻿using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace BookRentalSystem.Middlewares;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string errorMessage) = exception switch
        {
            ValidationException validationException => (400, validationException.Message),
            _ => (500, "Something went wrong.")
        };

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(errorMessage);

        return true;
    }
}
