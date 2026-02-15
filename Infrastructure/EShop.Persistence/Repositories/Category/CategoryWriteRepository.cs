using EShop.Persistence.Datas;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class CategoryWriteRepository : WriteGenericRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(AppDbContext context) : base(context)
    {
    }
}
