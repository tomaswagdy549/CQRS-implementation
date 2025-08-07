using AutoMapper;
using Catalog.Application.Features.Products.Dtos.Brands;
using Catalog.Application.Features.Products.Dtos.Products;
using Catalog.Core.Entities;

namespace Catalog.Application.Features.Products.MappingProfile;
public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Brand, BrandResponseDto>().ReverseMap();
        CreateMap<Product, ProductResponseDto>().ReverseMap();

        CreateMap<Product, CreateUpdateProductDto>().ReverseMap();

    }
}
