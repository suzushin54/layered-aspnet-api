using src.Catalog.ApplicationService;
using src.Catalog.Domain.RepositoryInterfaces;
using src.Catalog.Infrastructure.Repositories;
using src.Ordering.ApplicationService;
using src.Ordering.Domain.RepositoryInterfaces;
using src.Ordering.Infrastructure.Repositories;

using MonolithIProductService = src.Monolith.ApplicationService.IProductService;
using MonolithProductService = src.Monolith.ApplicationService.ProductService;
using MonolithIProductRepository = src.Monolith.Domain.RepositoryInterfaces.IProductRepository;
using MonolithProductRepository = src.Monolith.Infrastructure.Repositories.InMemoryProductRepository;
    
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

builder.Services.AddSingleton<MonolithIProductService, MonolithProductService>();
builder.Services.AddSingleton<MonolithIProductRepository, MonolithProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}