using Microsoft.AspNetCore.Mvc;
using src.Catalog.ApplicationService;
using src.Catalog.Domain.RepositoryInterfaces;

namespace src.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetProductById(Guid id)
    {
        var product = productService.GetProductById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
}