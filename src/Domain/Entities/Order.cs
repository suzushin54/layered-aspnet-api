namespace src.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public decimal TotalPrice { get; private set; }
    public List<OrderProduct> OrderProducts { get; private set; }
    public string ShippingAddress { get; private set; }
    public DateTime OrderDate { get; private set; }
    
    public Order(decimal totalPrice, List<OrderProduct> orderProducts, string shippingAddress)
    {
        if (string.IsNullOrEmpty(shippingAddress)) 
            throw new ArgumentException("Shipping address cannot be null or empty", nameof(shippingAddress));
        
        Id = Guid.NewGuid();
        TotalPrice = totalPrice;
        OrderProducts = orderProducts;   
        ShippingAddress = shippingAddress;
        OrderDate = DateTime.Now;
    }
}