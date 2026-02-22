using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Persistence.Datas;
using EShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Repositories;

public class AppUserReadRepository : ReadGenericRepository<AppUser>, IAppUserReadRepository
{
    public AppUserReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckUserByUsernameAndPassword(string username, string password)
    {
        var user = await _table.FirstOrDefaultAsync(x=> x.Username == username && x.Password == password);

        return user is not null;
    }

    public async Task<AppUser> GetUserByEmail(string email)
    {
        return await _table.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<AppUser> GetUserByUsername(string username)
    {
        return await _table.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<AppUser> GetUserByUsernameAndPassword(string username, string password)
    {
        return await _table.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
    }
}
