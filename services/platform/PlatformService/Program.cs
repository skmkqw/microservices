using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

if (builder.Environment.IsProduction())
{
	Console.WriteLine("--> Using SQL Server DB");
	builder.Services.AddDbContext<AppDbContext>(opts =>
		opts.UseSqlServer(builder.Configuration.GetConnectionString("Default_MSSQL")));
}
else
{
	Console.WriteLine("--> Using InMemory DB");
	builder.Services.AddDbContext<AppDbContext>(opts => opts.UseInMemoryDatabase("InMemory"));
}

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

var app = builder.Build();

DbPrep.PrepPopulation(app, builder.Environment.IsProduction());

app.MapControllers();
app.Run();
