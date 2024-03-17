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
            new Product(Guid.NewGuid(), "Product1", "Book", "Description1", "https://example.com/image1.jpg",
                "Manufacturer1", 100, false, true, false, 10, true, 1),
            new Product(Guid.NewGuid(), "Product2", "Video", "Description2", "https://example.com/image2.jpg",
                "Manufacturer2", 200, false, false, true, 20, false, 2),
            new Product(Guid.NewGuid(), "Product3", "Stationery", "Description3", "https://example.com/image3.jpg",
                "Manufacturer3", 300, true, true, false, 30, true, 3),
            new Product(Guid.NewGuid(), "Product4", "Book", "Description4", "https://example.com/image4.jpg",
                "Manufacturer4", 400, true, false, true, 40, false, 4),
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
