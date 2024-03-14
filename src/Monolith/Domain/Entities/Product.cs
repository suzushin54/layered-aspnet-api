using src.Monolith.Domain.Enums;

namespace src.Monolith.Domain.Entities;

public class Product
{
    // 商品ID
    public Guid Id { get; private set; }

    // 商品名
    public string Name { get; private set; }

    // 商品説明
    public string Description { get; private set; }

    // 商品画像URL
    public string ImageUrl { get; private set; }

    // メーカー
    public string Manufacturer { get; private set; }

    // 価格
    public decimal Price { get; private set; }

    // 商品ステータス
    public ProductStatus Status { get; private set; }

    // 定期購入可能商品
    public bool CanSubscribe { get; private set; }

    // 個数
    public int Quantity { get; private set; }

    // 軽減税率対象
    public bool IsReducedTax { get; private set; }

    // 表示順
    public int DisplayOrder { get; private set; }

    public Product(Guid id, string name, string description, string imageUrl, string manufacturer, decimal price,
        bool canSubscribe, int quantity, bool isReducedTax, int displayOrder)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));

        if (string.IsNullOrEmpty(description))
            throw new ArgumentException("Description cannot be null or empty", nameof(description));

        if (string.IsNullOrEmpty(imageUrl))
            throw new ArgumentException("ImageUrl cannot be null or empty", nameof(imageUrl));

        if (string.IsNullOrEmpty(manufacturer))
            throw new ArgumentException("Manufacturer cannot be null or empty", nameof(manufacturer));

        if (price < 0)
            throw new ArgumentException("Price cannot be negative", nameof(price));

        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative", nameof(quantity));

        if (displayOrder < 0)
            throw new ArgumentException("DisplayOrder cannot be negative", nameof(displayOrder));

        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Manufacturer = manufacturer;
        Price = price;
        Status = ProductStatus.InStock;
        CanSubscribe = canSubscribe;
        Quantity = quantity;
        IsReducedTax = isReducedTax;
        DisplayOrder = displayOrder;
    }
}