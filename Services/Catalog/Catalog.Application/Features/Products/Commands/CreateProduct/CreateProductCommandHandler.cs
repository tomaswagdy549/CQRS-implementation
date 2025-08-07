using AutoMapper;
using Catalog.Application.Features.Products.Dtos.Products;
using Catalog.Application.Features.Products.Queries.GetAllProductsQuery;
using Catalog.Core.Entities;
using Catalog.Core.Repositories.IProduct;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Commands.CreateProductCommand;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllProductsQueryHandler> _logger;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        var newProduct = await _productRepository.CreateProduct(product, cancellationToken);

        var productResponse = _mapper.Map<ProductResponseDto>(newProduct);

        return productResponse;
    }
}
