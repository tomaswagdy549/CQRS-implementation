using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Contexts;
public static class BrandContextSeed
{
    public static async Task SeedDataAsync(IMongoCollection<Brand> brandCollection, CancellationToken cancellationToken)
    {
        var hasBrand = await brandCollection.Find(_ => true).AnyAsync(cancellationToken);
        if (hasBrand)
            return;

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData", "brands.json");

        if (!File.Exists(filePath))
            return;

        try
        {
            var brands = await File.ReadAllTextAsync(filePath, cancellationToken);
            var brandList = JsonSerializer.Deserialize<List<Brand>>(brands, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (brandList != null && brandList.Count > 0)
            {
                await brandCollection.InsertManyAsync(brandList, cancellationToken: cancellationToken);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while seeding brands: {ex.Message}");
        }
    }

}
