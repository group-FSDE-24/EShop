using EShop.Persistence.Datas;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Repositories.Common;

namespace EShop.Persistence.Repositories;

public class CustomerWriteRepository : WriteGenericRepository<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(AppDbContext context) : base(context)
    {
    }
}
