using EShop.Persistence.Datas;
using EShop.Domain.Entities.Concretes;
using EShop.Application.Repositories;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class ProductReadRepository : ReadGenericRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
