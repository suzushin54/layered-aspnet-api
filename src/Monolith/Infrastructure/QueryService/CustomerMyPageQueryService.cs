using src.Monolith.ApplicationService.QueryServiceInterface;
using src.Monolith.ApplicationService.ReadModel;
using src.Monolith.Domain.Enums;

namespace src.Monolith.Infrastructure.QueryService;

public class CustomerMyPageQueryService : ICustomerMyPage
{
    private static List<CustomerMyPage> _customerMyPages = [];

    public CustomerMyPageQueryService()
    {
        _customerMyPages =
        [
            new CustomerMyPage(new Guid(), "John Doe", CustomerRank.Gold, 3,
            [
                new OrderSummary(new Guid(), DateTime.Now, 1000, 3),
                new OrderSummary(new Guid(), DateTime.Now, 2000, 5),
                new OrderSummary(new Guid(), DateTime.Now, 3000, 7)
            ]),
        ];
    }
    
    public CustomerMyPage GetCustomerMyPage(Guid customerId)
    {
        // 本来はDBから取得するが、今回はモックデータを返す
        // 条件を無視して返す
        return _customerMyPages.FirstOrDefault();
    }
}