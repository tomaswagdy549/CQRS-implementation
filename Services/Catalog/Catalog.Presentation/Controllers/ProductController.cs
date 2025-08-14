using Catalog.Api.Controllers;
using Catalog.Application.Features.Products.Commands.CreateProductCommand;
using Catalog.Application.Features.Products.Dtos.Products;
using Catalog.Application.Features.ProductType.Commands.CreateProductType;
using Catalog.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Presentation.Controllers
{
    public class ProductController : BaseApiController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [Route("Add-Product")]
        public async Task<GenericResponse<ProductResponseDto>> AddProduct(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createProductCommand, cancellationToken);
            return result;
        }

    }
}
