using MediatR;
using EShop.Application.DTOS;
using EShop.Application.Services.Abstracts;

namespace EShop.Application.Behaviors.Common.Query.Product.GetAll;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
{
    private readonly IProductService _productService;

    public GetAllProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<GetAllProductResponse> Handle(
        GetAllProductRequest request,
        CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(new PaginationDTO
        {
            Page = request.Page,
            PageSize = request.PageSize
        });

        return new GetAllProductResponse
        {
            Products = products
        };
    }
}
