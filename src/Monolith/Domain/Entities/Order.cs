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
    // NOTE: Productモデルを流用しているため、個数を持たせないといけないなどおかしなことになっている例
    public List<Product> OrderProducts { get; private set; }

    // 配送先住所
    public string ShippingAddress { get; private set; }

    // 注文日時
    public DateTime OrderDate { get; private set; }

    public Order(int usedPoints, List<Product> orderProducts, string shippingAddress,
        DateTime orderDate)
    {
        if (orderProducts == null || orderProducts.Count == 0)
            throw new ArgumentException("OrderProducts cannot be null or empty", nameof(orderProducts));
        OrderProducts = orderProducts;
        
        if (string.IsNullOrEmpty(shippingAddress))
            throw new ArgumentException("ShippingAddress cannot be null or empty", nameof(shippingAddress));
        ShippingAddress = shippingAddress;
        
        // 小計の計算
        // FIXME: 個数を考慮出来ていない
        SubTotal = orderProducts.Sum(p => p.Price);

        // 送料計算(送料無料の対象かどうかの判断)
        CalculateShippingFee();

        // NOTE: 複数の割引が存在しており、割引順が不具合を生みそうな気配がある
        // 新商品割引
        ApplyNewReleaseDiscount();
        // セット割引 
        ApplySetDiscount();

        // 値割引後の金額が確定したら、ポイントを使う場合の計算
        ApplyPointDiscount(usedPoints);

        Id = Guid.NewGuid();
        UsedPoints = usedPoints;
        TotalPrice = SubTotal + ShippingFee;
        OrderDate = orderDate;
    }

    // ポイントを使う場合の計算
    private void ApplyPointDiscount(int usedPoints)
    {
        if (usedPoints <= 0)
            return;

        // 小計が0未満にならないように
        if (SubTotal - usedPoints < 0)
            throw new ArgumentException("TotalPrice cannot be less than 0", nameof(usedPoints));

        // 小計からポイントを引く
        SubTotal -= usedPoints;
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

    // 商品合計が10,000円以上で送料無料。それ以外は一律800円
    // 購入してくれた金額で判断するため、値割引前の金額で判断する
    private void CalculateShippingFee()
    {
        ShippingFee = SubTotal >= 10000 ? 0 : 800;
    }
}