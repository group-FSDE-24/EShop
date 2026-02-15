using EShop.Persistence.Datas;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class OrderReadRepository : ReadGenericRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
