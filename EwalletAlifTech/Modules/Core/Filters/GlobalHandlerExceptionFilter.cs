using EwalletAlifTech.Modules.Core.Exceptions;
using EwalletAlifTech.Modules.Core.Responses;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EwalletAlifTech.Modules.Core.Filters
{
    public class GlobalHandlerExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {   
            if (context.Exception is ResourceNotFoundException)
            {
                context.Result = new ErrorJsonObjectResult(code: (short) HttpStatusCode.RESOURCE_NOT_FOUND, message:context.Exception.Message);
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ValidationException)
            {
                context.Result = new ErrorJsonObjectResult(code: (short)HttpStatusCode.VALIDATION_EXCEPTION, message: context.Exception.Message);

                context.ExceptionHandled = true;
            }
            else if (context.Exception is LogicException)
            {
                context.Result = new ErrorJsonObjectResult(code: (short)HttpStatusCode.UNKNOWN_ERROR, message: context.Exception.Message);
                context.ExceptionHandled = true;
            }
            else if (context.Exception is AccessForbiddenException)
            {
                context.Result = new ErrorJsonObjectResult(code: (short)HttpStatusCode.FORBIDDEN, message: context.Exception.Message);
                context.ExceptionHandled = true;
            }
            else if (context.Exception != null)
            {
                var loggerFactory = context.HttpContext.RequestServices.GetService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger(nameof(GlobalHandlerExceptionFilter));
                logger.LogError($"Message: {context.Exception.Message}, Trace:{context.Exception.StackTrace}");

                context.Result = new ErrorJsonObjectResult(code: (short)HttpStatusCode.UNKNOWN_ERROR, message: "Unknown error.");
                context.ExceptionHandled = true;
            }
        }
    }
}
