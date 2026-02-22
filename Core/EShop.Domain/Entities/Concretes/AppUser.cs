using EShop.Domain.Entities.Abstracts;

namespace EShop.Domain.Entities.Concretes;

public class AppUser : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}
