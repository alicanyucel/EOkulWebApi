using eOkulServer.Domain.Abstracts;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace eOkulServer.WebAPI.Middlewares;

public sealed class MyExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = 500;
        httpContext.Response.ContentType = "application/json";
        Result<string> error = default!;

        if (exception.GetType() == typeof(ValidationException))
        {
            var errors = ((ValidationException)exception).Errors.Select(s => s.PropertyName).ToList();
            error = Result<string>.Failure(errors, 500);
        }
        else
        {
            error = Result<string>.Failure(exception.Message, 500);
        }

        string errorString = JsonSerializer.Serialize(error);
        await httpContext.Response.WriteAsync(errorString);

        return true;
    }
}
