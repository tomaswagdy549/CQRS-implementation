using Catalog.Application.Common.Interfaces;
using Catalog.Application.Features.Products.Dtos.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.Features.Products.Commands.CreateProductCommand;
public record CreateProductCommand(string Name, IFormFile Picture,Guid BrandId, Guid ProductTypeId, string Description, decimal Price, bool IsAvailable) : IGenericResponseRequest<ProductResponseDto>;
