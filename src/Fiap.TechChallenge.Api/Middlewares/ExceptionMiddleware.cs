using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.TechChallenge.Api.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (ValidationException ex)
        {
            await HandleValidationExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        Console.WriteLine($"Error: {exception.Message}");
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(new
        {
            context.Response.StatusCode,
            Message = "We have some problems, please try again later.",
        } ));
    }
    private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException validationException)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        var errorValidations = validationException.Errors.GroupBy(x => x.PropertyName);
        var dictionaryErrors = errorValidations
            .ToDictionary(x => x.Key,
                x => x.Select(error => error.ErrorMessage).ToArray());
        
        var validationProblemDetails = new ValidationProblemDetails(dictionaryErrors);
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(
            validationProblemDetails));
    }

}