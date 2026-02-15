namespace EShop.Application.DTOS.Product;

public class AddProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int? Stock { get; set; }

    public int CategoryId { get; set; }
}
