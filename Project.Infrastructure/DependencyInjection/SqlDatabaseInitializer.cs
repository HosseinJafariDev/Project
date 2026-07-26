using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Persistence;
using Project.Infrastructure.Persistence.Identity;

namespace Project.Infrastructure.DependencyInjection;

public static class SqlDatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var db = services.GetRequiredService<PageDbContext>();

        await db.Database.MigrateAsync();

        var seeder = services.GetRequiredService<IdentitySeeder>();
    }
}