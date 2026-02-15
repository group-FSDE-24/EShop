using EShop.Domain.Entities.Common;

namespace EShop.Application.Repositories.Common;

public interface IWriteGenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    void Update(T entity);
    void Delete(T entity);
    Task Delete(int id);
    void DeleteRange(List<T> entities);
    Task SaveChangeAsync();

}


/*
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangeAsync();
 */

