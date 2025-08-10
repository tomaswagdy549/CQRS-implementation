using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Common.Interfaces
{
    interface IGenericResponseRequestHandler<TRequest,TResponse> : IRequestHandler<TRequest, GenericResponse<TResponse>>
        where TRequest : IGenericResponseRequest<TResponse>
    {
    }
}
