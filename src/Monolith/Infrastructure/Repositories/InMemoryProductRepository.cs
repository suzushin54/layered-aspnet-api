using src.Monolith.Domain.Entities;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private static List<Product>? _products;

    public InMemoryProductRepository()
    {
        _products =
        [
            new Product(new Guid(), "Keyboard", 222.0m),
            new Product(new Guid(), "Mouse", 1980.0m),
            new Product(new Guid(), "Monitor", 244998.0m),
        ];
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products ?? Enumerable.Empty<Product>();
    }

    public Product? GetProductById(Guid id)
    {
        return _products?.FirstOrDefault(p => p.Id == id);
    }
}
