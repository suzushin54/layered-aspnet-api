namespace src.Ordering.ApplicationService.Dto;

public class CreateOrderDto
{
    public decimal TotalPrice { get; set; }
    public List<CreateOrderProductDto> OrderProducts { get; set; }
    public string ShippingAddress { get; set; }
}

public class CreateOrderProductDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
