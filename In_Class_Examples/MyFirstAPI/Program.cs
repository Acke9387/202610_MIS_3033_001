using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DB_128040_practiceContext") ?? throw new InvalidOperationException("Connection string 'DB_128040_practiceContext' not found.");

builder.Services.AddDbContext<DB_128040_practiceContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI( options =>
    { 
        options.SwaggerEndpoint("/openapi/v1.json", "MyFirstAPI v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
