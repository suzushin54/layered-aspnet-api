namespace src.Monolith.ApplicationService.Dto;

public class CreateMonolithOrderDto
{
    public List<Guid> OrderProductIds { get; set; }
    public string ShippingAddress { get; set; }
}

