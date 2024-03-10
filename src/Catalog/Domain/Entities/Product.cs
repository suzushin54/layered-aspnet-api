using src.Catalog.Domain.Enums;

namespace src.Catalog.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public ProductStatus Status { get; private set; }
    
    public Product(Guid id, string name, decimal price)
    {
        if (string.IsNullOrEmpty(name)) 
            throw new ArgumentException("Name cannot be null or empty", nameof(name));

        if (price < 0)
            throw new ArgumentException("Price cannot be negative", nameof(price));
        
        Id = id;
        Name = name;
        Price = price;
        Status = ProductStatus.InStock;
    }
}