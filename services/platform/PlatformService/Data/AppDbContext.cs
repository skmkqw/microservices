using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

class AppDbContext : DbContext
{
	public DbSet<Platform> Platforms { get; set; }
}