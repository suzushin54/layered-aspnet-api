using Microsoft.AspNetCore.Mvc;
using src.Ordering.ApplicationService;
using src.Ordering.ApplicationService.Dto;

namespace src.Presentation;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = orderService.GetOrders();
        return Ok(orders);
    }
    
    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        if (createOrderDto.OrderProducts.Count == 0)
        {
            return BadRequest(new { message = "Order must have at least one product" });
        }

        orderService.CreateOrder(createOrderDto);

        return Ok(new { message = "Order created successfully" });
    }
}