using src.Monolith.ApplicationService.ReadModel;

namespace src.Monolith.ApplicationService.QueryServiceInterface;

public interface ICustomerMyPage
{
    CustomerMyPage GetCustomerMyPage(Guid customerId);
}