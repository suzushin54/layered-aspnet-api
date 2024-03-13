using src.Monolith.Domain.Entities;

namespace src.Monolith.Domain.RepositoryInterfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Product? GetProductById(Guid id);
}
