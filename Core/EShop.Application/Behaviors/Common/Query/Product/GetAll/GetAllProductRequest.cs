using MediatR;

namespace EShop.Application.Behaviors.Common.Query.Product.GetAll;

public class GetAllProductRequest : IRequest<GetAllProductResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}
