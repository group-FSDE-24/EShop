using EShop.Application.Services.Abstracts;
using EShop.Infrastructure.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Infrastructure;

public static class RegisterService
{
    public static void AddInfrastructureRegister(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();


    }
}
