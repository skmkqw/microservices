using PlatformService.Models;

namespace PlatformService.Data;

class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _dbContext;

    public PlatformRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreatePlatform(Platform platform)
    {
        _dbContext.Platforms.Add(platform);
    }

    public Platform? GetPlatformById(int id)
    {
        return _dbContext.Platforms.Find(id);
    }

    public IEnumerable<Platform> GetPlatforms()
    {
        return _dbContext.Platforms;
    }

    public bool SaveChanges()
    {
        return _dbContext.SaveChanges() >= 0;
    }
}