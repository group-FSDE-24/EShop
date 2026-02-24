using EShop.Domain.Entities.Abstracts;

namespace EShop.Domain.Entities.Concretes;

public class AppUser : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }

    // ---------------------------------------

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }
    public DateTime? RefreshTokenCreatedDate { get; set; }



    // ---------------------------------------

    // ---------------------------------------

    public string? RePasswordToken { get; set; }
    public DateTime? RePasswordExpireDate { get; set; }
    public DateTime? RePasswordCreatedDate { get; set; }



    // ---------------------------------------


    public virtual ICollection<Order> Orders { get; set; }
}
