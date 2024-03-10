using src.Ordering.Domain.Entities;

namespace src.Ordering.Domain.RepositoryInterfaces;

public interface IOrderRepository
{
    IEnumerable<Order>? GetOrders();
    void Save(Order order);
}