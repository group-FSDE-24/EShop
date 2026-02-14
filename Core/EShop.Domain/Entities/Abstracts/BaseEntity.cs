using EShop.Domain.Entities.Common;

namespace EShop.Domain.Entities.Abstracts;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
}
