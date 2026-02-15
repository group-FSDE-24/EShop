using EShop.Persistence.Datas;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class ProductWriteRepository : WriteGenericRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(AppDbContext context) : base(context)
    {
    }
}
