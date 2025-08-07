using Catalog.Core.Entities;

namespace Catalog.Core.Repositories.IProductType;
public interface IProductTypeRepository
{
    Task<IEnumerable<ProductType>> GetAllProductTypesAsync(CancellationToken cancellationToken = default);
    Task<ProductType> CreateProductType(ProductType productType, CancellationToken cancellationToken = default);
}
