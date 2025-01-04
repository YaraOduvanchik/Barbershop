using Barbershop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.DAL;

public static class MigrationManager
{
    public static async Task Migrate(this IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<BarbershopContextFactory>()
            .CreateContext();

        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

        await context.Database.MigrateAsync();
    }
}