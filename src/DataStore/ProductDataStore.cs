using src.Domain.Entities;

namespace src.DataStore
{
    public class ProductDataStore
    {
        // This is example data 
        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Product 1", Price = 100 },
            new Product { Id = 2, Name = "Product 2", Price = 200 },
            new Product { Id = 3, Name = "Product 3", Price = 300 },
        };
        
        // This method returns all products
        public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);
        
        public IEnumerable<Product> GetProducts() => _products;
    }
}