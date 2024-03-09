using Microsoft.AspNetCore.Mvc;
using src.Domain.RepositoryInterfaces;

namespace src.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = productRepository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetProductById(Guid id)
    {
        var product = productRepository.GetProductById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
}