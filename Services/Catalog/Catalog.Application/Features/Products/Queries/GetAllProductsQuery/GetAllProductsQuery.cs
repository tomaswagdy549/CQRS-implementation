using Catalog.Application.Features.Products.Dtos.Products;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsQuery;
public class GetAllProductsQuery : IRequest<IList<ProductResponseDto>>
{
}
