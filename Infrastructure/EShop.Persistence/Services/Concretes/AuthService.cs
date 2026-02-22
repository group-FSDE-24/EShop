using EShop.Application.Services.Abstracts;

namespace EShop.Persistence.Services.Concretes;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;

    public AuthService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }


}
