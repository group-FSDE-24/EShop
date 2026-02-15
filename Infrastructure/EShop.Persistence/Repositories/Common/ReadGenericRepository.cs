using System.Linq.Expressions;
using EShop.Persistence.Datas;
using EShop.Domain.Entities.Common;
using EShop.Application.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Repositories.Common;

public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity, new()
{
    public ReadGenericRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _table;
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _table.FirstOrDefaultAsync(x => x.Id == id)!;
    }

    public async Task<IQueryable<T>> GetExpressionAsync(Expression<Func<T, bool>> expression)
    {
        return _table.Where(expression);
    }
}
