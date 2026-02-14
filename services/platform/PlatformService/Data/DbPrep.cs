using PlatformService.Models;

namespace PlatformService.Data;

static class DbPrep
{
    public static void PrepPopulation(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        SeedData(context);
    }

    private static void SeedData(AppDbContext dbContext)
    {
        if (!dbContext.Platforms.Any())
        {
            Console.WriteLine("--> Seeding platform data");
            dbContext.Platforms.AddRange(
            [
                new Platform() { Name = ".NET", Publisher = "Microsoft" },
                new Platform() { Name = "SQL Server Express", Publisher = "Microsoft" },
                new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computer Foundation" }
            ]);
            Console.WriteLine("--> Completed seeding platform data");
        }
        else
        {
            Console.WriteLine("--> Platform data is already present");
        }
    }
}