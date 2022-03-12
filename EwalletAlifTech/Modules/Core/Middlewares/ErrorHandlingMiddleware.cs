using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Core.Exceptions;
using EwalletAlifTech.Modules.Core.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EwalletAlifTech.Modules.Core.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException e)
            {
                var result = new JsonResponseObject(code: (int)HttpStatusCode.VALIDATION_EXCEPTION, message: e.Message);

                await this.ExceptionResponse(context, result);
            }
            catch (AccessForbiddenException e)
            {
                var result = new JsonResponseObject(code: (int) HttpStatusCode.FORBIDDEN,
                    message: e.Message);
                await this.ExceptionResponse(context, result);
            }
            catch (LogicException e)
            {
                var result = new JsonResponseObject(code: (int)HttpStatusCode.UNKNOWN_ERROR,
                    message: e.Message);
                await this.ExceptionResponse(context, result);
            }
            catch (Exception e)
            {
                var result = new JsonResponseObject(code: (int)HttpStatusCode.UNKNOWN_ERROR,
                    message: "Unknown error.");

                var loggerFactory = context.RequestServices.GetService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger(nameof(ErrorHandlingMiddleware));
                logger.LogError($"Message: {e.Message}, Trace:{e.StackTrace}");

                await this.ExceptionResponse(context, result);
            }

        }
        private async Task ExceptionResponse(HttpContext context,JsonResponseObject result)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
