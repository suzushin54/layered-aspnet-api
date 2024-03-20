using src.Monolith.ApplicationService.Dto;
using src.Monolith.Domain.Entities;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.ApplicationService;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
    Product? GetProductById(Guid id);
    
    void CreateProduct(CreateMonolithProductDto createMonolithProductDto);
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
    
    public void CreateProduct(CreateMonolithProductDto createMonolithProductDto)
    {
       var product = new Product(
           Guid.NewGuid(),
           createMonolithProductDto.Name,
           createMonolithProductDto.Category,
           createMonolithProductDto.Description,
           createMonolithProductDto.ImageUrl,
           createMonolithProductDto.Manufacturer,
           createMonolithProductDto.Price,
           createMonolithProductDto.IsNewRelease,
           createMonolithProductDto.CanSubscribe,
           createMonolithProductDto.IsMadeToOrder,
           createMonolithProductDto.Quantity,
           createMonolithProductDto.IsReducedTax,
           createMonolithProductDto.DisplayOrder
       );
     
       _productRepository.Save(product);
    }
}
