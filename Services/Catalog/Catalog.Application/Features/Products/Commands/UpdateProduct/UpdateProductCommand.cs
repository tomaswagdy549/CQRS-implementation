using Catalog.Application.Features.Products.Dtos.Products;
using MediatR;

namespace Catalog.Application.Features.Products.Commands.UpdateProductCommand;
public class UpdateProductCommand : IRequest<ProductResponseDto>
{
    public CreateUpdateProductDto CreateUpdateProductDto { get; set; }

    public UpdateProductCommand(CreateUpdateProductDto dto)
    {
        CreateUpdateProductDto = dto;
    }
}
