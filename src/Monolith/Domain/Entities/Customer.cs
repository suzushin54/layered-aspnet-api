using src.Monolith.Domain.Enums;

namespace src.Monolith.Domain.Entities;

public class Customer
{
    // 顧客ID
    public readonly Guid Id;
    // 顧客名
    public string Name { get; private set; }
    // Email
    public string Email { get; private set; }
    // 住所
    public string Address { get; private set; }
    // 注文履歴
    public List<Order>? Orders { get; private set; }
    // 注文回数によって変わるランク
    public CustomerRank Rank { get; private set; }
    // メモ
    public string Memo { get; private set; }
    // 問い合わせ回数 
    public int InquiryCount { get; private set; }
    // 最終ログイン
    public DateTime LastLogin { get; private set; }

    public Customer(string name, string email, string address, CustomerRank rank, string memo,
        int inquiryCount, DateTime lastLogin, List<Order>? orders)
    {
        Id = Guid.NewGuid();
        
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        Name = name;

        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        Email = email;

        Address = address;

        Rank = rank;

        Memo = memo;

        InquiryCount = inquiryCount;
        
        Orders = orders;

        LastLogin = lastLogin;
    }
}