using src.Monolith.Domain.Entities;

namespace src.Monolith.Domain.RepositoryInterfaces;

public interface IOrderRepository
{
    IEnumerable<Order>? GetOrders();
    void Save(Order order);
}