using EShop.Domain.Entities.Abstracts;

namespace EShop.Application.Repositories;

public interface IGenericRepository<T> where T: BaseEntity, new()
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangeAsync();


}
