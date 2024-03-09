using Microsoft.AspNetCore.Mvc;
using src.Domain.Entities;
using src.Domain.RepositoryInterfaces;
using src.Presentation.Dto;

namespace src.Presentation;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderRepository orderRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = orderRepository.GetOrders();
        return Ok(orders);
    }
    
    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        if (createOrderDto == null)
        {
            return BadRequest("Order data is required.");
        }
        
        // debug log
        Console.WriteLine("CreateOrderDto: " + createOrderDto);

        var orderProducts = createOrderDto.OrderProducts.Select(
            op => new OrderProduct(op.ProductId, op.Quantity, op.Price)).ToList();

        var order = new Order(createOrderDto.TotalPrice, orderProducts, createOrderDto.ShippingAddress);

        orderRepository.Save(order);

        return Ok(new { orderId = order.Id, message = "Order created successfully" });
    }
}