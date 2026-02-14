using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<AppDbContext>(opts =>
  opts.UseInMemoryDatabase("InMemory"));
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

var app = builder.Build();

DbPrep.PrepPopulation(app);

app.MapControllers();
app.Run();
