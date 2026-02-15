using EShop.Domain.Entities.Common;

namespace EShop.Application.Repositories.Common;

// Signature
public interface IGenericRepository<T> where T : IBaseEntity, new()
{
}
