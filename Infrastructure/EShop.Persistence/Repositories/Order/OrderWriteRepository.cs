using EShop.Persistence.Datas;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class OrderWriteRepository : WriteGenericRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(AppDbContext context) : base(context)
    {
    }
}
