using Catalog.Core.Entities;

namespace Catalog.Core.Repositories.IProduct;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken = default);
    Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetProductByName(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetProductByBrand(string brand, CancellationToken cancellationToken = default);
    Task<Product> CreateProduct(Product product, CancellationToken cancellationToken = default);
    Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken = default);
    Task<bool> DeleteProduct(Product product, CancellationToken cancellationToken = default);
}
