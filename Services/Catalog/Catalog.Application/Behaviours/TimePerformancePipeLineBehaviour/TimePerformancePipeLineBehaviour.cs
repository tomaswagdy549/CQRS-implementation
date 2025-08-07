using Catalog.Application.Common.GenericResponse;
using MediatR;
using System.Diagnostics;

namespace Catalog.Application.Behaviours.TimePerformancePipeLineBehaviour
{
    public class TimePerformancePipeLineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);
            var response = await next();
            var type = response.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(GenericResponse<>))
            {
                long memoryAfter = GC.GetTotalMemory(true);
                stopwatch.Stop();
                var memoryUsed = memoryAfter - memoryBefore;
                type.GetProperty("TimeCollapsedInMilliSeconds")?.SetValue(response, stopwatch.ElapsedMilliseconds);
                type.GetProperty("MemoryUsedInBytes")?.SetValue(response, memoryUsed);
            }
            return response;
        }
    }
}
