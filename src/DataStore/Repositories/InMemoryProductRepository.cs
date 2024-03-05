using src.Domain.Entities;
using src.Domain.RepositoryInterfaces;

namespace src.DataStore.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static List<Product>? _products;
        
        public InMemoryProductRepository()
        {
            _products =
            [
                new Product(1, "Product 1", 1000),
                new Product(2, "Product 2", 2000),
                new Product(3, "Product 3", 3000)
            ];
        }
        
        public IEnumerable<Product>? GetProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            return _products?.FirstOrDefault(p => p.Id == id);
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}