using PlatformService.Models;

namespace PlatformService.Data;

interface IPlatformRepository
{
	bool SaveChanges();

	Platform? GetPlatformById(int id);

	IEnumerable<Platform> GetPlatforms();

	void CreatePlatform(Platform platform);
}