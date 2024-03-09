using src.Domain.Entities;
using src.Domain.RepositoryInterfaces;

namespace src.DataStore.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private static List<Product>? _products;

    public InMemoryProductRepository()
    {
        _products =
        [
            new Product(new Guid(), "Keyboard", 20.0m),
            new Product(new Guid(), "Mouse", 10.0m),
            new Product(new Guid(), "Monitor", 100.0m),
        ];
    }

    public IEnumerable<Product>? GetProducts()
    {
        return _products;
    }

    public Product? GetProductById(Guid id)
    {
        return _products?.FirstOrDefault(p => p.Id == id);
    }

    public void SaveProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Guid id)
    {
        throw new NotImplementedException();
    }
}