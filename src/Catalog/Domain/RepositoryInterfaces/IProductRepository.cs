using src.Catalog.Domain.Entities;

namespace src.Catalog.Domain.RepositoryInterfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Product? GetProductById(Guid id);
}