using App.Infrastructure;
using Catalog.Core.Entities;
using Catalog.Core.Repositories.IProductType;
using Catalog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories.ProductTypes
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public DbSet<ProductType> _productTypes { get; set; }
        public ProductTypeRepository(ApplicationDbContext applicationDbContext)
        {
            _productTypes = applicationDbContext.Set<ProductType>();
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync(CancellationToken cancellationToken = default)
        {
            return await _productTypes
                        .ToListAsync(cancellationToken);
        }

        public async Task<ProductType> CreateProductType(ProductType productType, CancellationToken cancellationToken = default)
        {
           var reuslt = await _productTypes.AddAsync(productType);
           return productType;
        }
    }
}
