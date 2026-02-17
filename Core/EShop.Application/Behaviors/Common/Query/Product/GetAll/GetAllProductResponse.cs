using EShop.Application.DTOS.Product;

namespace EShop.Application.Behaviors.Common.Query.Product.GetAll;

public class GetAllProductResponse
{
    public IEnumerable<AllProductDTO> Products { get; set; }
}
