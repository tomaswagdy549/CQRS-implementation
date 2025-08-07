using Catalog.Application.Common.Interfaces;
using Catalog.Application.Features.ProductType.Dtos.CreateProductTypeResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.ProductType.Commands.CreateProductType
{
    public record CreateProductTypeCommand(string Name) : IGenericResponseRequest<CreateProductTypeResponse>;
}
