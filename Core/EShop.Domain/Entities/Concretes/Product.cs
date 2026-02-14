using EShop.Domain.Entities.Abstracts;

namespace EShop.Domain.Entities.Concretes;

public  class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public double? Price { get; set; }
    public int? Stock { get; set; }

    // FK
    public int CategoryId { get; set; }

    // NP
    public Category Category { get; set; }
}
