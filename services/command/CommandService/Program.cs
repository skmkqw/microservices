using CommandService.Data;
using CommandService.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseInMemoryDatabase("InMemory"));
builder.Services.AddScoped<ICommandRepository, CommandRepository>();

builder.Services.AddAutoMapper(config => config.AddProfile<CommandsProfile>());

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
