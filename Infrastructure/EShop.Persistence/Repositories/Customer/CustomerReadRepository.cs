using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Datas;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class CustomerReadRepository : ReadGenericRepository<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
