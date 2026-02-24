using Microsoft.AspNetCore.Mvc;
using EShop.Application.DTOS.Auth;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Application.Services.Abstracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Text;
using EShop.Domain.Helpers;
using System.Threading.Tasks;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAppUserReadRepository _appUserReadRepository;
    private readonly IAppUserWriteRepository _appUserWriteRepository;
    private readonly ITokenService _tokenService;

    public AuthController(IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository, ITokenService tokenService)
    {
        _appUserReadRepository = appUserReadRepository;
        _appUserWriteRepository = appUserWriteRepository;
        _tokenService = tokenService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var user = await _appUserReadRepository.GetUserByUsername(loginDTO.Username);

        if (user is null)
            return BadRequest("Invalid username or password");

        using var hmac = new HMACSHA256(user.PasswordSalt);
        var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

        var isCheck = computedPass.SequenceEqual(user.PasswordHash);

        if (!isCheck)
        {
            return BadRequest("Invalid Password");
        }

        var token = _tokenService.AccessToken(user);
        var refreshToken = _tokenService.RefreshToken();

        await SetRefreshToken(user, refreshToken);

        return Ok(new { token = token });
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddUser([FromBody] AddAppUserDTO userDTO)
    {
        var user = await _appUserReadRepository.GetUserByUsername(userDTO.Username);

        if (user is not null)
            return BadRequest("This user already exist");

        using var hmac = new HMACSHA256();

        var newUser = new AppUser()
        {
            Name = userDTO.Name,
            Surname = userDTO.Surname,
            Email = userDTO.Email,
            Username = userDTO.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password!)),
            PasswordSalt = hmac.Key,
            Role = userDTO.Role
        };

        await _appUserWriteRepository.AddAsync(newUser);
        await _appUserWriteRepository.SaveChangeAsync();

        return Ok();
    }


    // Role-u Admin olanlarin goreceyi action yazilacaq
    [Authorize(Roles = "Admin")]
    [HttpGet("[action]")]
    public IActionResult SomeThing()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        var claims = identity.Claims;

        var user = new AppUser()
        {
            Username = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
            Email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
            Role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
        };


        return Ok(user);
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
            return BadRequest("Invalid Request token");

        var user = await _appUserReadRepository.GetRefreshToken(refreshToken);

        if (user is null)
            return BadRequest("Invalid user");

        var accessToken = _tokenService.AccessToken(user);
        var refreshTokenObj = _tokenService.RefreshToken();

        await SetRefreshToken(user, refreshTokenObj);

        return Ok(new { accessToken = accessToken });
    }

    private async Task SetRefreshToken(AppUser user, RefreshToken refreshToken)
    {
        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = refreshToken.ExpireDate
        };

        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        user.RefreshToken = refreshToken.Token;
        user.RefreshTokenExpireDate = refreshToken.ExpireDate;
        user.RefreshTokenCreatedDate = refreshToken.CreatedDate;

        _appUserWriteRepository.Update(user);
        await _appUserWriteRepository.SaveChangeAsync();

    }

}
