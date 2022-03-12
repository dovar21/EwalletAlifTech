using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EwalletAlifTech.Modules.Core.Responses
{
    public class SuccessJsonObjectResult : IActionResult
    {
        private readonly JsonResponseObject _result;

        public SuccessJsonObjectResult(Int16 code = 0, object data = null, string message = null)
        {
            _result = new JsonResponseObject(code, data, message, null);
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new JsonResult(_result)
            {
                StatusCode = StatusCodes.Status200OK,
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}