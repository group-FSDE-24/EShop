using EShop.Application.DTOS;
using Microsoft.AspNetCore.Mvc;
using EShop.Application.DTOS.Product;
using Microsoft.AspNetCore.Authorization;
using EShop.Application.Services.Abstracts;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO model)
     => Ok(await _productService.GetAllAsync(model));


    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        var result = await _productService.AddAsync(model);

        if (!result)
            return BadRequest();

        return StatusCode(204);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
     => await _productService.DeleteAsync(id) ? StatusCode(204) : BadRequest();


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _productService.GetByIdAsync(id);

        if (result is null)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDTO model)
    {
        var result = await _productService.UpdateAsync(id, model);

        if (!result)
            return BadRequest();

        return StatusCode(204);
    }

    [HttpGet("GetProductsByCategoryId/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategoryId([FromRoute] int categoryId)
    {
        var result = await _productService.GetProductsByCategoryId(categoryId);

        if (result is null)
            return BadRequest();

        return Ok(result);
    }

}
