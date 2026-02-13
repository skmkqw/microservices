using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts =>
  opts.UseInMemoryDatabase("InMemory"));

var app = builder.Build();

app.UseHttpsRedirection();
app.Run();
