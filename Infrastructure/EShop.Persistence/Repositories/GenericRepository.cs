using EShop.Persistence.Datas;
using Microsoft.EntityFrameworkCore;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Abstracts;

namespace EShop.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
    }

    public Task<List<T>> GetAllAsync()
    {
        return _appDbContext.Set<T>().ToListAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _appDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id)!;
    }

    public async Task SaveChangeAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
    }
}
