using Catalog.Application.Features.Products.Queries;
using Catalog.Application.Features.ProductType.Commands.CreateProductType;
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
        public async Task<IActionResult> CreateProductType(CreateProductTypeCommand createProductTypeCommand, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createProductTypeCommand, cancellationToken);
            return Ok(result);
        }

    }
}
