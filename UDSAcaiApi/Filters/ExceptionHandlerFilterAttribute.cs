using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UDSAcaiApi.Filters
{
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //if (context.Exception is BusinessException ||
            //    context.Exception is AuthorizationException ||
            //    context.Exception is ValidationException ||
            //    context.Exception is ContentLenghtException)
            //{
            //    var statusCode = (int)HttpStatusCode.BadRequest;

            //    if (context.Exception is AuthorizationException)
            //    {
            //        statusCode = (int)HttpStatusCode.Unauthorized;
            //    }

            //    if (context.Exception is ContentLenghtException)
            //    {
            //        statusCode = (int)HttpStatusCode.RequestEntityTooLarge;
            //    }

            //    context.HttpContext.Response.ContentType = "application/json";
            //    context.HttpContext.Response.StatusCode = statusCode;
            //    context.Result = new JsonResult(new
            //    {
            //        error = context.Exception.Message
            //    });

            //    return;
            //}

            //var code = HttpStatusCode.InternalServerError;

            //if (context.Exception is NotFoundException)
            //{
            //    code = HttpStatusCode.NotFound;
            //}

            //context.HttpContext.Response.ContentType = "application/json";
            //context.HttpContext.Response.StatusCode = (int)code;

            //if (context.Exception is PersistenceException)
            //{
            //    context.Result = new JsonResult(new
            //    {
            //        error = context.Exception.Message,
            //        innerException = context.Exception.InnerException?.Message,
            //        stackTrace = context.Exception.StackTrace
            //    });

            //    return;
            //}

            context.Result = new JsonResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
