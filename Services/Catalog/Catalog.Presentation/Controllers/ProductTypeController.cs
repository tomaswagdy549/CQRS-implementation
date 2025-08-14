using Catalog.Application.Features.Products.Queries;
using Catalog.Application.Features.ProductType.Commands.CreateProductType;
using Catalog.Application.Features.ProductType.Dtos.CreateProductTypeResponse;
using Catalog.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    public class ProductTypeController:BaseApiController
    {
        public ProductTypeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("product-types")]
        public async Task<GenericResponse<CreateProductTypeResponse>> CreateProductType(CreateProductTypeCommand createProductTypeCommand, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createProductTypeCommand, cancellationToken);
            return result;
        }

    }
}
