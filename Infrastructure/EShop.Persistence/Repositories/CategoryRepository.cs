using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Datas;

namespace EShop.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext) { }

}
