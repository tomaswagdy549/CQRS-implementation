using Catalog.Application.Common.GenericResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Common.Interfaces
{
    interface IGenericResponseRequest<TResponse>:IRequest<GenericResponse<TResponse>>
    {
    }
}
