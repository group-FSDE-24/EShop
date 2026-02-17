using MediatR;
using Microsoft.AspNetCore.Mvc;
using EShop.Application.Behaviors.Common.Query.Product.GetAll;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductWithMediatRController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductWithMediatRController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 10)
    {
        var response = await _mediator.Send(new GetAllProductRequest
        {
            Page = page,
            PageSize = pageSize
        });

        return Ok(response);
    }
}
