using App.Infrastructure;
using Catalog.Core.Entities;
using Catalog.Core.Repositories.IProduct;
using Microsoft.EntityFrameworkCore;
namespace Catalog.Infrastructure.Repositories.Products;
public class ProductRepository : IProductRepository
{
    public DbSet<Product> _products { get; set; }
    public ProductRepository(ApplicationDbContext applicationDbContext)
    {
        _products = applicationDbContext.Set<Product>();
    }

    public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken = default)
    {
        return await _products
                    .SingleAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductByBrand(string brand, CancellationToken cancellationToken = default)
    {
        return await _products
                    .Where(p => p.Brand.Name.ToLower().Contains(brand.ToLower()))
                    .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllProducts(CancellationToken cancellationToken = default)
    {
        return await _products
                    .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name, CancellationToken cancellationToken = default)
    {
        return await _products
                    .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                    .ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateProduct(Product product, CancellationToken cancellationToken = default)
    {
        try
        {
            var updatedProduct = _products.Update(product);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public async Task<Product> CreateProduct(Product product, CancellationToken cancellationToken = default)
    {
        await _products
            .AddAsync(product, cancellationToken: cancellationToken);

        return product;
    }

    public async Task<bool> DeleteProduct(Product product, CancellationToken cancellationToken = default)
    {
        try
        {
            var deletedProduct = _products
            .Remove(product);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
