using Microsoft.AspNetCore.Mvc;
using src.DataStore;

namespace src.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDataStore _productDataStore = new ProductDataStore();

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productDataStore.GetProducts());
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productDataStore.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}

