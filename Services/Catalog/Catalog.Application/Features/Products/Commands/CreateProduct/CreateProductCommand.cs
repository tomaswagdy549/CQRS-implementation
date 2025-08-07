using Catalog.Application.Features.Products.Dtos.Products;
using MediatR;

namespace Catalog.Application.Features.Products.Commands.CreateProductCommand;
public record CreateProductCommand() : IRequest<ProductResponseDto>;
