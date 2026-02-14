using EShop.Application.Repositories;
using EShop.Persistence.Datas;
using EShop.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Persistence;

public static class RegisterService
{
    public static void AddPersistenceRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        
        AddRepositoriesExtention(services);
        AddServiceExtention(services);
    }

    private static void AddRepositoriesExtention(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }

    private static void AddServiceExtention(IServiceCollection services)
    {
        // 
    }
}
