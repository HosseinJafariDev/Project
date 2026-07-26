using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Project.Infrastructure.DependencyInjection;

public static class MongoDatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var database = services.GetRequiredService<IMongoDatabase>();

        var collections = await database.ListCollectionNames().ToListAsync();

        if (!collections.Contains("Logs"))
            await database.CreateCollectionAsync("Logs");

        if (!collections.Contains("Notifications"))
            await database.CreateCollectionAsync("Notifications");
    }
}