using EShop.Persistence.Datas;
using EShop.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using EShop.Application.Repositories.Common;

namespace EShop.Persistence.Repositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;
    protected DbSet<T> _table;

    public GenericRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
        _table = _context.Set<T>();
    }
}
