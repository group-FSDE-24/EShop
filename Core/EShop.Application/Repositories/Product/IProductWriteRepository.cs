using EShop.Domain.Entities.Concretes;
using EShop.Application.Repositories.Common;

namespace EShop.Application.Repositories;

public interface IProductWriteRepository : IWriteGenericRepository<Product>
{
}
