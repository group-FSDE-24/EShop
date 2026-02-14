using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Datas;

namespace EShop.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext) { }

}
