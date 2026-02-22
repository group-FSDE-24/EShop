using EShop.Domain.Entities.Concretes;

namespace EShop.Application.DTOS.Auth;

public class AddAppUserDTO
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }
}
