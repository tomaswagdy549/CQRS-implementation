using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Contexts;
public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
    IMongoCollection<Brand> Brands { get; }
    IMongoCollection<ProductType> ProductTypes { get; }
}
