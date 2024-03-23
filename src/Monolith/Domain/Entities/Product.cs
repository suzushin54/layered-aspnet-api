using src.Monolith.Domain.Enums;

namespace src.Monolith.Domain.Entities;

public class Product
{
    // 最大注文可能個数
    public const int MaxOrderQuantity = 20;

    // 商品ID
    public Guid Id { get; private set; }
    // 商品名
    public string Name { get; private set; }
    // カテゴリ
    public string Category { get; private set; }
    // 商品説明
    public string Description { get; private set; }
    // 商品画像URL
    public string ImageUrl { get; private set; }
    // メーカー
    public string Manufacturer { get; private set; }
    // 出荷元
    public string Shipper { get; private set; }
    // 価格
    public decimal Price { get; private set; }
    // 商品ステータス
    public ProductStatus Status { get; private set; }
    // 新商品フラグ
    public bool IsNewRelease { get; private set; }
    // 定期購入可能商品
    public bool CanSubscribe { get; private set; }
    // 受注生産品フラグ
    public bool IsMadeToOrder { get; private set; }
    // OOC2020記念グッズフラグ (NOTE: 終売しているが管理画面で参照)
    public bool IsOoc2020Goods { get; private set; }
    // 個数
    public int Quantity { get; set; }

    // 軽減税率対象
    public bool IsReducedTax { get; private set; }

    // 表示順
    public int DisplayOrder { get; private set; }

    public Product(Guid id, string name, string category, string description, string imageUrl, string manufacturer,
        decimal price, bool isNewRelease, bool canSubscribe, bool isMadeToOrder, int quantity, bool isReducedTax,
        int displayOrder)
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
        Category = category;
        Description = description;
        ImageUrl = imageUrl;
        Manufacturer = manufacturer;
        Price = price;
        Status = ProductStatus.InStock;
        IsNewRelease = isNewRelease;
        CanSubscribe = canSubscribe;
        IsMadeToOrder = isMadeToOrder;
        Quantity = quantity;
        IsReducedTax = isReducedTax;
        DisplayOrder = displayOrder;
    }

    // 最初にありがちなメソッド
    // 通常商品と一緒に購入可能かどうかを判断
    public bool IsPurchaseWith()
    {
        // 受注生産かどうかで判断している。意味はわかるが、この手のメソッドが量産されそうな気配を感じる
        return !IsMadeToOrder;
    }

    // 次に見かけるメソッド
    // この商品が他の商品と同時に購入可能かどうかを判断
    public bool CanPurchaseWith(Product product)
    {
        // 受注生産と通常商品の組み合わせは同時に購入できないというルールがあることがわかる
        // しかしProductがProductを受け取って判断しているのは違和感がある
        return IsMadeToOrder != product.IsMadeToOrder;
    }

    // 動画と書籍を一緒に買うと割引
    // これは実際には購入に関するルールであるが、ProductがCategoryを持っているためここに書かれてしまっている
    public bool IsSetDiscount(Product[] products)
    {
        return products.Any(p => p.Category == "動画") && products.Any(p => p.Category == "書籍");
    }

    // まとめて購入できる個数の範囲内かどうか
    // これも実際には購入に関するルールである
    public bool IsWithinPurchaseLimit()
    {
        return MaxOrderQuantity >= Quantity;
    }
}