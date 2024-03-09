using src.Domain.Entities;

namespace src.Domain.RepositoryInterfaces;

public interface IOrderRepository
{
    IEnumerable<Order>? GetOrders();
    void Save(Order order);
}