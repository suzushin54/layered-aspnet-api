using src.Monolith.Domain.Entities;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.ApplicationService;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
    Product? GetProductById(Guid id);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public Product? GetProductById(Guid id)
    {
        return _productRepository.GetProductById(id);
    }
}
