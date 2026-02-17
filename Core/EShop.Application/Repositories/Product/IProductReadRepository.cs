using EShop.Domain.Entities.Concretes;
using EShop.Application.Repositories.Common;
using EShop.Application.DTOS.Product;

namespace EShop.Application.Repositories;

public interface IProductReadRepository : IReadGenericRepository<Product>
{
    Task<List<AllProductDTO>> GetProductsByCategoryId(int categoryId);
}
