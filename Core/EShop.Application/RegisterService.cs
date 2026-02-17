using Microsoft.Extensions.DependencyInjection;
using EShop.Application.Behaviors.Common.Query.Product.GetAll;

namespace EShop.Application;

public static class  RegisterService
{
    public static void AddApplicationRegister(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetAllProductQueryHandler).Assembly));
    }
}