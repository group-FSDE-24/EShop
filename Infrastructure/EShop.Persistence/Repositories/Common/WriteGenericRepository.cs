using EShop.Persistence.Datas;
using EShop.Domain.Entities.Common;
using EShop.Application.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Repositories.Common;

public class WriteGenericRepository<T> : GenericRepository<T>, IWriteGenericRepository<T> where T : class, IBaseEntity, new()
{
    public WriteGenericRepository(AppDbContext context) : base(context)
    {
    }


    public async Task AddAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task AddRangeAsync(List<T> entities)
    {
        await _table.AddRangeAsync(entities);
    }

    public void Delete(T entity)
    {
        _table.Remove(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);

        _table.Remove(entity!);
    }

    public void DeleteRange(List<T> entities)
    {
        _table.RemoveRange(entities);
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }
}
