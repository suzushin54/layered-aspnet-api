namespace src.Monolith.Domain.Entities;

public class Customer
{
    // 顧客ID
    public Guid Id { get; private set; }

    // 顧客名
    public string Name { get; private set; }

    // Email
    public string Email { get; private set; }

    // 住所
    public string Address { get; private set; }

    // 注文履歴
    public List<Order>? Orders { get; private set; }

    // ランク
    // NOTE: 注文回数によって変わるランク。ランクによって割引率が変わる
    public string Rank { get; private set; }

    // メモ
    // NOTE: 顧客に関するメモ。カスタマーサポートで使用
    public string Memo { get; private set; }

    // レーティング
    // NOTE: 顧客の評価を表す数値。0.0から5.0の範囲で表現される
    // (カスタマーサポートで要注意顧客を判断するために使っている)
    public decimal Rating { get; private set; }

    // 最終ログイン
    public DateTime LastLogin { get; private set; }

    public Customer(string name, string email, string address, string rank, string memo,
        decimal rating, DateTime lastLogin, List<Order>? orders)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        Name = name;

        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        Email = email;

        Address = address;

        if (string.IsNullOrEmpty(rank))
            throw new ArgumentException("Rank cannot be null or empty", nameof(rank));
        Rank = rank;

        Memo = memo;

        Rating = rating;
        
        Orders = orders;

        LastLogin = lastLogin;
    }
}