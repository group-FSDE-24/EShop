using System.Linq.Expressions;
using EShop.Domain.Entities.Common;

namespace EShop.Application.Repositories.Common;

public interface IReadGenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IQueryable<T>> GetExpressionAsync(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(int id);
}

/*
 
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangeAsync();
 
 */