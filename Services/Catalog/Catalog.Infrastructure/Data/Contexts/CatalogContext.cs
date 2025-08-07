using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Contexts;
public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products { get; }

    public IMongoCollection<Brand> Brands { get; }

    public IMongoCollection<ProductType> ProductTypes { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var cleint = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var database = cleint.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

        Products = database.GetCollection<Product>(configuration["DatabaseSettings:ProductsCollection"]);
        Brands = database.GetCollection<Brand>(configuration["DatabaseSettings:BrandsCollection"]);
        ProductTypes = database.GetCollection<ProductType>(configuration["DatabaseSettings:ProductTypesCollection"]);

       // _= BrandContextSeed.SeedDataAsync(Brands, default);
        //SeedGenericCollection.SeedCollectionAsync(Brands);
    }
}
