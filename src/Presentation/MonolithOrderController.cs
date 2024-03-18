using Microsoft.AspNetCore.Mvc;
using src.Monolith.ApplicationService;
using src.Monolith.ApplicationService.Dto;

namespace src.Presentation;

[ApiController]
[Route("api/[controller]")]
public class MonolithOrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = orderService.GetOrders();
        return Ok(orders);
    }
    
    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateMonolithOrderDto createMonolithOrderDto)
    {
        if (createMonolithOrderDto.OrderProductIds.Count == 0)
        {
            return BadRequest(new { message = "Order must have at least one product" });
        }

        orderService.CreateOrder(createMonolithOrderDto);

        return Ok(new { message = "Order created successfully" });
    }
}