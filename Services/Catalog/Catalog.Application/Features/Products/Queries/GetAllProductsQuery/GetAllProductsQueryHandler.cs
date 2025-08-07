using AutoMapper;
using Catalog.Application.Features.Products.Dtos.Products;
using Catalog.Core.Repositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsQuery;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponseDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllProductsQueryHandler> _logger;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<IList<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllProducts(cancellationToken);
        _logger.LogInformation("Fetching all products from the repository.");

        var productResponse = _mapper.Map<IList<ProductResponseDto>>(products);

        return productResponse;
    }
}
