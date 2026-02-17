using EShop.Application.DTOS;
using EShop.Application.DTOS.Product;

namespace EShop.Application.Services.Abstracts;

public interface IProductService
{
    Task<IEnumerable<AllProductDTO>> GetAllAsync(PaginationDTO model);
    Task<bool> AddAsync(AddProductDto model);
    Task<bool> DeleteAsync(int id);
    Task<AllProductDTO> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, UpdateProductDTO model);
}
