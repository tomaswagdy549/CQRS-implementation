using MongoDB.Driver;
using System.Text.Json;

public static class SeedGenericCollection
{
    public static async Task SeedCollectionAsync<T>(
        IMongoCollection<T> collection,
        string jsonFilePath,
        CancellationToken cancellationToken = default) where T : class
    {
        try
        {
            var hasData = await collection.Find(_ => true).AnyAsync(cancellationToken);
            if (hasData)
                return;

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine($"File not found: {jsonFilePath}");
                return;
            }

            var json = await File.ReadAllTextAsync(jsonFilePath, cancellationToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<List<T>>(json, options);

            if (data != null && data.Count > 0)
            {
                await collection.InsertManyAsync(data, cancellationToken: cancellationToken);
                Console.WriteLine($"Seeded {data.Count} records into {typeof(T).Name} collection.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while seeding {typeof(T).Name}: {ex.Message}");
        }
    }
}
