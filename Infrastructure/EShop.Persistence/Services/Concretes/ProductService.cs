using EShop.Application.DTOS;
using EShop.Application.DTOS.Product;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Application.Services.Abstracts;

namespace EShop.Persistence.Services.Concretes;

public class ProductService : IProductService
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<bool> AddAsync(AddProductDto model)
    {
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

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productReadRepository.GetByIdAsync(id);

        if (product is null)
            return false;

        await _productWriteRepository.Delete(id);
        await _productWriteRepository.SaveChangeAsync();

        return true;
    }

    public async Task<IEnumerable<AllProductDTO>> GetAllAsync(PaginationDTO model)
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

        return allProductDto;
    }

    public async Task<AllProductDTO> GetByIdAsync(int id)
    {
        var product = await _productReadRepository.GetByIdAsync(id);

        if (product is null)
            return null;

        var mappedData = new AllProductDTO()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryName = product.Category.Name,
            Id = product.Id
        };

        return mappedData;
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductDTO model)
    {
        var product = await _productReadRepository.GetByIdAsync(id);

        if (product is null)
            return false;

        product.Name = model.Name;
        product.Price = model.Price;
        product.Description = model.Description;
        product.CategoryId = model.CategoryId;
        product.Stock = model.Stock;

        await _productWriteRepository.SaveChangeAsync();

        return true;
    }
}
