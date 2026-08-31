using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBookGenerator.Communication.Response;
using MyRecipeBookGenerator.Exception;
using MyRecipeBookGenerator.Exception.ExceptionsBase;

namespace MyRecipeBookGenerator.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidatorException errorOnValidatorException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var errors = errorOnValidatorException.GetErrors();
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(errors));
        }
        else
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ExeptionsMessageResource.UNKNOWN_ERROR));
        }

    }
}
