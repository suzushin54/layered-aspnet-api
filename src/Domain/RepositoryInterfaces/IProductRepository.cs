using src.Domain.Entities;

namespace src.Domain.RepositoryInterfaces;

public interface IProductRepository
{
    IEnumerable<Product>? GetProducts();
    Product? GetProductById(Guid id);
    void SaveProduct(Product product);
    void DeleteProduct(Guid id);
}