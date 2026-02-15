using Microsoft.AspNetCore.Mvc;
using EShop.Application.Repositories;
using EShop.Application.DTOS.Category;
using EShop.Domain.Entities.Concretes;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public CategoryController(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> Add([FromBody] AddCategoryDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        var newProduct = new Category()
        {
            Name = model.Name,
            Description = model.Description
        };

        await _categoryWriteRepository.AddAsync(newProduct);
        await _categoryWriteRepository.SaveChangeAsync();

        return Ok(newProduct);
    }

}
