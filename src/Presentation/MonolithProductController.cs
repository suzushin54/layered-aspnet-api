using Microsoft.AspNetCore.Mvc;
using src.Monolith.ApplicationService;
using src.Monolith.ApplicationService.Dto;

namespace src.Presentation;

[ApiController]
[Route("api/[controller]")]
public class MonolithProductController(IProductService productService) : ControllerBase
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
    
    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateMonolithProductDto createMonolithProductDto)
    {
        productService.CreateProduct(createMonolithProductDto);
        return Ok(new { message = "Product created successfully" });
    }
}