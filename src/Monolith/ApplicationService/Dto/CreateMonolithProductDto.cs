namespace src.Monolith.ApplicationService.Dto;

public class CreateMonolithProductDto
{
    // 商品名
    public string Name { get; set; }

    // カテゴリ
    public string Category { get; set; }

    // 商品説明
    public string Description { get; set; }

    // 商品画像URL
    public string ImageUrl { get; set; }

    // メーカー
    public string Manufacturer { get; set; }

    // 価格
    public decimal Price { get; set; }

    // 新商品フラグ
    public bool IsNewRelease { get; set; }

    // 定期購入可能商品
    public bool CanSubscribe { get; set; }

    // 受注生産品フラグ
    public bool IsMadeToOrder { get; set; }

    // 最大注文可能数
    public int Quantity { get; set; }

    // 軽減税率対象
    public bool IsReducedTax { get; set; }

    // 表示順
    public int DisplayOrder { get; set; }
}