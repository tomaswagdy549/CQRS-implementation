using Catalog.Application.Features.Products.Queries;
using Catalog.Application.Features.Products.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

public class CatalogsController : BaseApiController
{
    public CatalogsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("brands")]
    public async Task<IActionResult> GetBrands(CancellationToken cancellationToken)
    {
        var query = new GetAllBrandsQuery();
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}
