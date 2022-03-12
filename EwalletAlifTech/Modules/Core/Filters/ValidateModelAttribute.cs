using System.Linq;
using EwalletAlifTech.Modules.Core.Responses;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EwalletAlifTech.Modules.Core.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                object errors = actionContext.ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage);

                actionContext.Result =
                    new ErrorJsonObjectResult(1, errors: errors, message: "Some fields are incorrect");
            }

        }
    }
}
