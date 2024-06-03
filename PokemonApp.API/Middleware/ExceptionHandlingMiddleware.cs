using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PokemonApp.Infrastructure.Exceptions;
using System.Net;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception?.InnerException is PokemonsDatabaseException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(GetProblemDetails(
                HttpStatusCode.InternalServerError, 
                exception.InnerException.Message, 
                context.TraceIdentifier)); 
        }

        return context.Response.WriteAsync(GetProblemDetails(
                        HttpStatusCode.InternalServerError,
                        exception.Message,
                        context.TraceIdentifier));
    }

    private static string GetProblemDetails(HttpStatusCode statusCode, string message, string traceIdentifier)
    {
        return JsonConvert.SerializeObject(
            new ProblemDetails
            {
                Status = (int)statusCode,
                Title = "An error occurred while processing your request.",
                Detail = message,
                Instance = traceIdentifier,
                Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1"
            },
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
    }
}