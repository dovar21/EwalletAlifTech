using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EwalletAlifTech.Modules.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Context;

namespace EwalletAlifTech.Modules.Core.Middlewares
{
    public class LoggingContextMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingContextMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var appName = context.RequestServices.GetRequiredService<IConfiguration>().GetSection("App")["name"];
            
            if(string.IsNullOrEmpty(appName))
                throw new LogicException("AppName not found");
            
            using (LogContext.PushProperty("AppName", appName))
            {
                await _next.Invoke(context);
            }
        }
    }
}
