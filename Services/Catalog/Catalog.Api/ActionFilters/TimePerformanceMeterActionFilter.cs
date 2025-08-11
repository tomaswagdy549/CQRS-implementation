using Catalog.Core.Entities;
using Catalog.Presentation.MiddleWares;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Catalog.Api.ActionFilters
{
    public class TimePerformanceMeterActionFilter : IActionFilter
    {
        private Stopwatch _stopwatch;
        private long _memoryBefore;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            _memoryBefore = GC.GetTotalMemory(true);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);
            long memoryUsed = memoryAfter - _memoryBefore;

            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                var type = objectResult.Value.GetType();
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(GenericResponse<>))
                {
                    type.GetProperty("TimeCollapsedInMilliSeconds")?.SetValue(objectResult.Value, _stopwatch.ElapsedMilliseconds);
                    type.GetProperty("MemoryUsedInBytes")?.SetValue(objectResult.Value, memoryUsed);
                }
            }
        }
    }
}
