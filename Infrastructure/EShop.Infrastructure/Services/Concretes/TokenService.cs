using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using EShop.Domain.Entities.Concretes;
using Microsoft.Extensions.Configuration;
using EShop.Application.Services.Abstracts;
using EShop.Domain.Helpers;
using System.Security.Cryptography;

namespace EShop.Infrastructure.Services.Concretes;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string AccessToken(AppUser appUser)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Issuer = _configuration["JWT:IsSuer"],
            Audience = _configuration["JWT:Audience"],
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, appUser.Username!),
                new Claim(ClaimTypes.Role, appUser.Role!),
                new Claim(ClaimTypes.Email, appUser.Email!),
            })
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }

    public RefreshToken RefreshToken()
    {
        var refreshToken = new RefreshToken()
        {
            ExpireDate = DateTime.Now.AddMinutes(30),
            CreatedDate = DateTime.Now,
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64))
        };

        return refreshToken;
    }

    public RePasswordToken RePasswordToken()
    {
        var rePasswordToken = new RePasswordToken()
        {
            ExpireDate = DateTime.Now.AddMinutes(30),
            CreatedDate = DateTime.Now,
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64))
        };

        return rePasswordToken;
    }
}
