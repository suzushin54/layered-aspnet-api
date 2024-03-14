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
            new Product(Guid.NewGuid(), "Product 1", "Description 1", "https://example.com/image1.jpg", "Manufacturer 1", 100, true, 10, true, 1),
            new Product(Guid.NewGuid(), "Product 2", "Description 2", "https://example.com/image2.jpg", "Manufacturer 2", 200, false, 20, false, 2),
            new Product(Guid.NewGuid(), "Product 3", "Description 3", "https://example.com/image3.jpg", "Manufacturer 3", 300, true, 30, true, 3),
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
