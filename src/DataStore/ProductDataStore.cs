using src.Domain.Entities;

namespace src.DataStore
{
    public class ProductDataStore
    {
        // This is example data 
        private static List<Product> _products = new()
        {
            new Product(1, "Product 1", 100),
            new Product(2, "Product 2", 200),
            new Product(3, "Product 3", 300),
        };
        
        // This method returns all products
        public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);
        
        public IEnumerable<Product> GetProducts() => _products;
    }
}