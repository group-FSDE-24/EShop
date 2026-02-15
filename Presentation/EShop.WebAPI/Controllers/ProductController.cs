using EShop.Application.DTOS;
using Microsoft.AspNetCore.Mvc;
using EShop.Application.DTOS.Product;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO model)
    {
        var products = await _productReadRepository.GetAllAsync();

        var productWithPagionation = products
                                     .Skip(model.Page * model.PageSize)
                                     .Take(model.PageSize)
                                     .ToList();

        var allProductDto = productWithPagionation
                            .Select(x => new AllProductDTO()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description,
                                Price = x.Price,
                                Stock = x.Stock,
                                CategoryName = x.Category.Name
                            });

        return Ok(allProductDto);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);


        var newProduct = new Product()
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Stock = model.Stock,
            CategoryId = model.CategoryId
        };

        await _productWriteRepository.AddAsync(newProduct);
        await _productWriteRepository.SaveChangeAsync();

        return Ok(newProduct);
    }
}
