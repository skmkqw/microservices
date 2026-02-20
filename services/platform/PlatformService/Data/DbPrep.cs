using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

static class DbPrep
{
    public static void PrepPopulation(WebApplication app, bool isProduction = false)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        SeedData(context, isProduction);
    }

    private static void SeedData(AppDbContext dbContext, bool isProduction)
    {
        if (isProduction)
        {
            Console.WriteLine("--> Attempting to apply migrations");
            try
            {
                dbContext.Database.Migrate();
                Console.WriteLine("--> Applied migrations successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Failed to apply migrations: ${e.Message}");
            }
        }

        if (!dbContext.Platforms.Any())
        {
            Console.WriteLine("--> Seeding platform data");
            dbContext.Platforms.AddRange(
            [
                new Platform() { Name = ".NET", Publisher = "Microsoft" },
                new Platform() { Name = "SQL Server Express", Publisher = "Microsoft" },
                new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computer Foundation" }
            ]);

            dbContext.SaveChanges();

            Console.WriteLine("--> Completed seeding platform data");
        }
        else
        {
            Console.WriteLine("--> Platform data is already present");
        }
    }
}