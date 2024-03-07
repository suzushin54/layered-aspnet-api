namespace src.Domain.Entities;

public class OrderProduct
{
    public Guid Id { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    public OrderProduct(int productId, int quantity, decimal price)
    {
        if (productId <= 0)
            throw new ArgumentException("Product id cannot be less than or equal to zero", nameof(productId));
        
        if (quantity <= 0)
            throw new ArgumentException("Quantity cannot be less than or equal to zero", nameof(quantity));
        
        if (price <= 0)
            throw new ArgumentException("Price cannot be less than or equal to zero", nameof(price));
        
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}