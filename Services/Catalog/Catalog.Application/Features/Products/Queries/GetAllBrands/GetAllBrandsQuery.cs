using Catalog.Application.Features.Products.Dtos.Brands;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetAll;
public class GetAllBrandsQuery : IRequest<List<BrandResponseDto>>
{
}
