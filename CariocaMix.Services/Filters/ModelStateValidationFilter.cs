using CariocaMix.Service.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CariocaMix.Service.Filters
{
    public class ModelStateValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) {}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.GetReturnMessageResponse("Ocorreram erros de validação!");

                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}
