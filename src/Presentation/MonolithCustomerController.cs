using Microsoft.AspNetCore.Mvc;
using src.Monolith.ApplicationService;

namespace src.Presentation;

[ApiController]
[Route("api/[controller]")]
public class MonolithCustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = customerService.GetCustomers();
        return Ok(customers);
    }
    
    [HttpGet("{id:Guid}")]
    public IActionResult GetCustomerById(Guid id)
    {
        var customer = customerService.GetCustomerById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }
    
    [HttpGet("{id:Guid}/mypage")]
    public IActionResult GetCustomerMyPage(Guid id)
    {
        var customerMyPage = customerService.GetCustomerMyPage(id);
        return Ok(customerMyPage);
    }
}