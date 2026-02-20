using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Central.Wrappers.Generic;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EShop.WebAPI.Filters;


public class ExceptionGlobalFilter(ILogger<ExceptionGlobalFilter> logger) : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        logger.LogError(context.Exception, "Sorğunu emal edərkən xəta baş verdi");

        var responseModel = context.Exception switch
        {
            ValidationException validationEx => new Response<string>
            {
                IsSucceeded = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Messages.ValidationError",
                Errors = validationEx.Errors.Select(e => e.ErrorMessage).ToList()
            },
            _ => new Response<string>
            {
                IsSucceeded = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = context.Exception.Message,
                Errors = [context.Exception.InnerException?.Message ?? "Messages.UnexpectedError"]
            }
        };

        context.Result = new ObjectResult(responseModel)
        {
            StatusCode = (int)responseModel.StatusCode
        };
        context.ExceptionHandled = true;

        return Task.CompletedTask;
    }
}

