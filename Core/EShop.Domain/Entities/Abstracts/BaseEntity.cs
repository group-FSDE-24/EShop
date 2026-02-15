using EShop.Domain.Entities.Common;

namespace EShop.Domain.Entities.Abstracts;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
