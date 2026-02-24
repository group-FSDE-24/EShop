using Microsoft.AspNetCore.Mvc;
using EShop.Application.DTOS.Auth;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using EShop.Application.Services.Abstracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Text;

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

        if(!isCheck)
        {
            return BadRequest("Invalid Password");
        }
        // Yazilacaq

        var token = _tokenService.AccessToken(user);

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


}
