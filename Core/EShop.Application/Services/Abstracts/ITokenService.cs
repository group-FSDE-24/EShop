using EShop.Domain.Helpers;
using EShop.Domain.Entities.Concretes;

namespace EShop.Application.Services.Abstracts;

public interface ITokenService
{
    string AccessToken(AppUser appUser);
    RefreshToken RefreshToken();
    RePasswordToken RePasswordToken();
}
