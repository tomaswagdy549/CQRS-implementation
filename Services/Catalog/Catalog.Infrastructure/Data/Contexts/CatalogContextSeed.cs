namespace Catalog.Infrastructure.Data.Contexts;
public static class CatalogContextSeed
{
    public static async Task SeedAsync(ICatalogContext context, CancellationToken cancellationToken = default)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData");

        await SeedGenericCollection.SeedCollectionAsync(
            context.Brands,
            Path.Combine(basePath, "brands.json"),
            cancellationToken);

        await SeedGenericCollection.SeedCollectionAsync(
            context.ProductTypes,
            Path.Combine(basePath, "productTypes.json"),
            cancellationToken);

        await SeedGenericCollection.SeedCollectionAsync(
            context.Products,
            Path.Combine(basePath, "products.json"),
            cancellationToken);
    }
}

