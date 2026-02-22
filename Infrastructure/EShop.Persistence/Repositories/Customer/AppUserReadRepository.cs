using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Datas;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class AppUserReadRepository : ReadGenericRepository<AppUser>, IAppUserReadRepository
{
    public AppUserReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
