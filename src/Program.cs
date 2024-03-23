using src.Catalog.ApplicationService;
using src.Catalog.Domain.RepositoryInterfaces;
using src.Catalog.Infrastructure.Repositories;
using src.Ordering.ApplicationService;
using src.Ordering.Domain.RepositoryInterfaces;
using src.Ordering.Infrastructure.Repositories;

using MonolithICustomerService = src.Monolith.ApplicationService.ICustomerService;
using MonolithCustomerService = src.Monolith.ApplicationService.CustomerService;
using MonolithICustomerRepository = src.Monolith.Domain.RepositoryInterfaces.ICustomerRepository;
using MonolithCustomerRepository = src.Monolith.Infrastructure.Repositories.InMemoryCustomerRepository;

using MonolithIProductService = src.Monolith.ApplicationService.IProductService;
using MonolithProductService = src.Monolith.ApplicationService.ProductService;
using MonolithIProductRepository = src.Monolith.Domain.RepositoryInterfaces.IProductRepository;
using MonolithProductRepository = src.Monolith.Infrastructure.Repositories.InMemoryProductRepository;

using MonolithIOrderService = src.Monolith.ApplicationService.IOrderService;
using MonolithOrderService = src.Monolith.ApplicationService.OrderService;
using MonolithIOrderRepository = src.Monolith.Domain.RepositoryInterfaces.IOrderRepository;
using MonolithOrderRepository = src.Monolith.Infrastructure.Repositories.InMemoryOrderRepository;

// QueryService
using MonolithICustomerMyPage = src.Monolith.ApplicationService.QueryServiceInterface.ICustomerMyPage;
using MonolithCustomerMyPageQueryService = src.Monolith.Infrastructure.QueryService.CustomerMyPageQueryService;


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

builder.Services.AddSingleton<MonolithICustomerService, MonolithCustomerService>();
builder.Services.AddSingleton<MonolithICustomerRepository, MonolithCustomerRepository>();
builder.Services.AddSingleton<MonolithIProductService, MonolithProductService>();
builder.Services.AddSingleton<MonolithIProductRepository, MonolithProductRepository>();
builder.Services.AddSingleton<MonolithIOrderService, MonolithOrderService>();
builder.Services.AddSingleton<MonolithIOrderRepository, MonolithOrderRepository>();

builder.Services.AddSingleton<MonolithICustomerMyPage, MonolithCustomerMyPageQueryService>();

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