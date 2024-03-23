using src.Monolith.Domain.Enums;

namespace src.Monolith.ApplicationService.ReadModel;

public class CustomerMyPage
{
    // 顧客ID
    public readonly Guid Id;

    // 顧客名
    public string Name { get; private set; }

    // 注文回数によって変わるランク
    public CustomerRank Rank { get; private set; }

    // 直近3回の注文サマリー
    public List<OrderSummary> Recent3Orders { get; set; }

    // 総注文回数
    public int TotalOrderCount { get; private set; }

    public CustomerMyPage(Guid id, string name, CustomerRank rank, int totalOrderCount,
        List<OrderSummary> recent3Orders)
    {
        Id = id;

        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        Name = name;

        Rank = rank;

        TotalOrderCount = totalOrderCount;

        Recent3Orders = recent3Orders;
    }
}

public class OrderSummary
{
    // 注文ID
    public Guid Id { get; set; }

    // 注文日時
    public DateTime OrderDate { get; set; }

    // 注文金額
    public decimal TotalAmount { get; set; }

    // 注文商品数
    public int TotalQuantity { get; set; }

    public OrderSummary(Guid id, DateTime orderDate, decimal totalAmount, int totalQuantity)
    {
        Id = id;
        OrderDate = orderDate;
        TotalAmount = totalAmount;
        TotalQuantity = totalQuantity;
    }
}