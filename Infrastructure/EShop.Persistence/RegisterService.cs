using EShop.Persistence.Datas;
using Microsoft.EntityFrameworkCore;
using EShop.Application.Repositories;
using EShop.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using EShop.Persistence.Services.Concretes;
using EShop.Application.Services.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Persistence;

public static class RegisterService
{
    public static void AddPersistenceRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseLazyLoadingProxies()
               .UseSqlServer(
                    configuration.GetConnectionString("SqlServer")
                );
        });

        AddRepositoriesExtention(services);
        AddServiceExtention(services);
    }

    private static void AddRepositoriesExtention(IServiceCollection services)
    {
        //services.AddScoped<IProductRepository, ProductRepository>();
        //services.AddScoped<ICategoryRepository, CategoryRepository>();


        // Read
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();

        // Write
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

    }

    private static void AddServiceExtention(IServiceCollection services)
    {
        // 

        services.AddScoped<IProductService, ProductService>();
    }
}
