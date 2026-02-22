using EShop.Persistence.Datas;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class AppUserWriteRepository : WriteGenericRepository<AppUser>, IAppUserWriteRepository
{
    public AppUserWriteRepository(AppDbContext context) : base(context)
    {
    }
}
