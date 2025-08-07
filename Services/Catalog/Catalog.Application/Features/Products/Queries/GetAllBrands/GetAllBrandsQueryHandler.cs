using AutoMapper;
using Catalog.Application.Features.Products.Dtos.Brands;
using Catalog.Application.Features.Products.Queries.GetAll;
using Catalog.Core.Repositories.IBrand;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries.GetAllBrands;
public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;
    private readonly ILogger<GetAllBrandsQueryHandler> _logger;
    public GetAllBrandsQueryHandler(IMapper mapper, IBrandRepository brandRepository, ILogger<GetAllBrandsQueryHandler> logger)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
        _logger = logger;
    }

    public async Task<List<BrandResponseDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetAllBrandsQuery request {Timestamp}", DateTime.UtcNow);

        var brands = await _brandRepository.GetAllBrandAsync(cancellationToken);

        var brandResponse = _mapper.Map<List<BrandResponseDto>>(brands);

        return brandResponse;
    }
}
