using Catalog.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Mail;

namespace Catalog.Presentation.ActionFilters
{
    public class ActionResultFactoryActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var value = objectResult.Value;
                var type = objectResult.Value.GetType();
                if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(GenericResponse<>))
                {
                    var statusCodeProp = type.GetProperty(nameof(GenericResponse<object>.HttpStatusCode));
                    var statusCodeValue = statusCodeProp?.GetValue(objectResult.Value);
                    if (statusCodeValue is HttpStatusCode statusCode)
                    {
                        context.Result = MapToActionResult(statusCode, value);
                    }
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
        private IActionResult MapToActionResult(HttpStatusCode httpStatusCode,object response)
        {
            switch (httpStatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case System.Net.HttpStatusCode.NoContent:
                    return new NoContentResult();
                case System.Net.HttpStatusCode.Created:
                    return new CreatedResult("", response);
                case System.Net.HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case System.Net.HttpStatusCode.Forbidden:
                    return new ForbidResult();
                case System.Net.HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case System.Net.HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }

        }
    }
}
