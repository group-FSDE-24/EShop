using EShop.Domain.Entities.Concretes;

namespace EShop.Application.Services.Abstracts;

public interface ITokenService
{
    string AccessToken(AppUser appUser);
}
