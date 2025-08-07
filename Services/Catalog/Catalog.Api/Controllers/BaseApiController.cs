using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;
    public BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
