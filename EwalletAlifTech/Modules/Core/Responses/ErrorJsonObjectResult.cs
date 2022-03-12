using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EwalletAlifTech.Modules.Core.Responses
{
    public class ErrorJsonObjectResult: IActionResult
    {
        private readonly JsonResponseObject _result;

        public ErrorJsonObjectResult(Int16 code=0, object data = null, string message = null,
            object errors = null)
        {
            _result = new JsonResponseObject(code,data, message: message, errors: errors);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new JsonResult(_result)
            {
                StatusCode = StatusCodes.Status400BadRequest,
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
