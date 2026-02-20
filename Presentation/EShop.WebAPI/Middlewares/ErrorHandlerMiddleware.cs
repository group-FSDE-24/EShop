using System.Net;
using FluentValidation;
using Central.Wrappers.Generic;

namespace EShop.WebAPI.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger for logging errors.</param>
    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware to handle exceptions for the incoming request.
    /// </summary>
    /// <param name="context">The HttpContext for the current request.</param>
    /// <returns>A Task representing the asynchronous operation of exception handling.</returns>
    /// <remarks>
    /// This method catches various exceptions thrown during the execution of the request pipeline,
    /// logs the error, and returns an appropriate HTTP response based on the type of exception.
    /// Supported exceptions include custom application exceptions, database update errors, and more.
    /// </remarks>
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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, exception.Message);

        HttpStatusCode httpCode;
        var message = exception.Message;
        List<string> errors = null;

        switch (exception)
        {

            case ValidationException e:
                // custom application error
                httpCode = HttpStatusCode.BadRequest;
                errors = e.Errors.Select(e => e.ErrorMessage).ToList();
                break;
           
            case KeyNotFoundException:
                // not found error
                httpCode = HttpStatusCode.NotFound;
                break;

            default:
                // unhandled error
                httpCode = HttpStatusCode.InternalServerError;
                message = exception.Message;
                errors = [exception.Message];
                break;
        }

        context.Response.StatusCode = (int)httpCode;
        context.Response.ContentType = "application/json";

        var responseModel = Response<string>.Fail(httpCode, message, errors);

        var result = System.Text.Json.JsonSerializer.Serialize(responseModel);

        await context.Response.WriteAsync(result);
    }
}
