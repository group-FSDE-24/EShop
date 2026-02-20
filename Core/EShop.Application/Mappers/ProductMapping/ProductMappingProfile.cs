using AutoMapper;
using EShop.Application.DTOS.Product;
using EShop.Domain.Entities.Concretes;

namespace EShop.Application.Mappers.ProductMapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<AddProductDto, Product>();
    }
}
