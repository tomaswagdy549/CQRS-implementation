using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Presentation.ActionFilters
{
    public class ActionResultFactoryActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var wrapped = new
                {
                    status = objectResult.StatusCode ?? StatusCodes.Status200OK,
                    data = objectResult.Value,
                    message = "Success"
                };

                context.Result = new CreatedResult();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
