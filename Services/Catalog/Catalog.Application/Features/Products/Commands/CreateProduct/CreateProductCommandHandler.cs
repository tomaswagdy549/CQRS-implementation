using AutoMapper;
using Catalog.Application.Common.Interfaces;
using Catalog.Application.Features.Products.Dtos.Products;
using Catalog.Application.Features.Products.Queries.GetAllProductsQuery;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces.GenericRepositoryInterface;
using Catalog.Core.Interfaces.IFileManager;
using Catalog.Core.Repositories.IProduct;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Commands.CreateProductCommand;
public class CreateProductCommandHandler
    : IGenericResponseRequestHandler<CreateProductCommand, ProductResponseDto>
{
    //private readonly IProductRepository _productRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<CreateProductCommandHandler> _logger;
    private readonly IAdd<Product> _add;
    private readonly IFileManager _fileManager;

    public CreateProductCommandHandler(IAdd<Product> add,IFileManager fileManager, ILogger<CreateProductCommandHandler> logger)
    {
        //_productRepository = productRepository;
        //_mapper = mapper;
        _add = add;
        _logger = logger;
        _fileManager = fileManager;
    }

    public async Task<GenericResponse<ProductResponseDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();
        var uploadProductPictureResponse = await _fileManager.UploadFileAsync(request.Picture);
        if (!uploadProductPictureResponse.IsSucceed)
        {
            return new GenericResponse<ProductResponseDto>()
            {
                Data = null,
                Message = uploadProductPictureResponse.Message,
                HttpStatusCode = uploadProductPictureResponse.HttpStatusCode
            };
        }
        product.ImageFile = uploadProductPictureResponse.Data;
        await _add.AddAsync(product);
        var productResponse = product.Adapt<ProductResponseDto>();
        return new GenericResponse<ProductResponseDto>()
        {
            HttpStatusCode = System.Net.HttpStatusCode.Created,
            Message = "Product created succesfully",
            Data = productResponse
        };
    }

    //public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    //{
    //    var product = _mapper.Map<Product>(request);

    //    var newProduct = await _productRepository.CreateProduct(product, cancellationToken);

    //    var productResponse = _mapper.Map<ProductResponseDto>(newProduct);

    //    return productResponse;
    //}
}
