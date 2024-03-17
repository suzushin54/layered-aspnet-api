namespace src.Monolith.Domain.Entities;

public class Order
{
    // 注文ID
    public Guid Id { get; private set; }

    // 小計金額
    public decimal SubTotal { get; private set; }

    // 送料
    public decimal ShippingFee { get; private set; }

    // 利用ポイント
    public int UsedPoints { get; private set; }

    // 合計金額
    public decimal TotalPrice { get; private set; }

    // 注文商品
    public List<Product> OrderProducts { get; private set; }

    // 配送先住所
    public string ShippingAddress { get; private set; }

    // 注文日時
    public DateTime OrderDate { get; private set; }

    public Order(decimal shippingFee, int usedPoints, List<Product> orderProducts, string shippingAddress,
        DateTime orderDate)
    {
        if (orderProducts == null || orderProducts.Count == 0)
            throw new ArgumentException("OrderProducts cannot be null or empty", nameof(orderProducts));

        if (string.IsNullOrEmpty(shippingAddress))
            throw new ArgumentException("ShippingAddress cannot be null or empty", nameof(shippingAddress));

        // 小計の計算
        var subTotal = orderProducts.Sum(p => p.Price);
        // 合計金額の計算(小計 + 送料 - 利用ポイント)
        var totalPrice = subTotal + shippingFee - usedPoints;

        Id = Guid.NewGuid();
        SubTotal = subTotal;
        ShippingFee = shippingFee;
        UsedPoints = usedPoints;
        TotalPrice = totalPrice;
        OrderProducts = orderProducts;
        ShippingAddress = shippingAddress;
        OrderDate = orderDate;

        // NOTE: 複数の割引が存在しており、割引順が不具合を生みそうな気配がある
        // 新商品割引
        ApplyNewReleaseDiscount();
        // セット割引 
        ApplySetDiscount();
        // 送料計算
        ApplyFreeShipping();
        // 再計算
        TotalPrice = SubTotal + ShippingFee - UsedPoints;
    }

    // 動画と書籍を一緒に買うと30%割引
    private void ApplySetDiscount()
    {
        if (OrderProducts.Any(p => p.Category == "Video") && OrderProducts.Any(p => p.Category == "Book"))
        {
            TotalPrice *= 0.7m;
        }
    }
    
    // 新商品はその単価が10%割引される
    private void ApplyNewReleaseDiscount()
    {
        // OrderProductsを走査して、新商品だったら割引していく
        foreach (var product in OrderProducts.Where(product => product.IsNewRelease))
        {
            SubTotal -= product.Price * 0.1m;
        }
    }

    // 商品合計が10,000円以上で送料無料
    private void ApplyFreeShipping()
    {
        if (SubTotal >= 10_000)
        {
            ShippingFee = 0;
        }
    }
}