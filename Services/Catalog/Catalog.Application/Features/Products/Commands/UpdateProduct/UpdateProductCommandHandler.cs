using AutoMapper;
using Catalog.Application.Features.Products.Dtos.Products;
using Catalog.Core.Repositories.IProduct;
using DnsClient.Internal;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Commands.UpdateProductCommand;
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CreateUpdateProductDto;

        var existingProduct = await _productRepository.GetProductById(dto.Id, cancellationToken);
        if (existingProduct is null)
        {
            _logger.LogError($"Product with ID {dto.Id} not found.");
            throw new KeyNotFoundException($"Product with ID {dto.Id} not found.");
        }

        _mapper.Map(dto, existingProduct);

        var isUpdated = await _productRepository.UpdateProduct(existingProduct, cancellationToken);

        if (!isUpdated)
        {
            _logger.LogError($"Failed to update product with ID {dto.Id}.");
            throw new InvalidOperationException($"Failed to update product with ID {dto.Id}.");
        }

        var productResponse = _mapper.Map<ProductResponseDto>(existingProduct);

        return productResponse;
    }


}
