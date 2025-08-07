using Catalog.Application.Common.GenericResponse;
using Catalog.Application.Common.Interfaces;
using Catalog.Application.Features.ProductType.Commands.CreateProductType;
using Catalog.Application.Features.ProductType.Dtos.CreateProductTypeResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Behaviours.TimePerformancePipeLineBehaviour
{
    public class TimePerformancePipeLineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);
            var response = await next();
            if(response is GenericResponse<CreateProductTypeResponse> generic)
            {
                long memoryAfter = GC.GetTotalMemory(true);
                stopwatch.Stop();
                var memoryUsed = memoryAfter - memoryBefore;
                generic.TimeCollapsedInMilliSeconds = stopwatch.ElapsedMilliseconds;
                generic.MemoryUsedInBytes = memoryUsed;
            }
            return response;
        }
    }
}
