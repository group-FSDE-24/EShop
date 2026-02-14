using EShop.Domain.Entities.Abstracts;

namespace EShop.Domain.Entities.Concretes;

public  class Category : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    // NP
    public ICollection<Product>Products { get; set; }
}
