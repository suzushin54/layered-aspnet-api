using src.Domain.Entities;

namespace src.Domain.RepositoryInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product>? GetProducts();
        Product? GetProductById(int id);
        void SaveProduct(Product product);
        void DeleteProduct(int id);
    }
}