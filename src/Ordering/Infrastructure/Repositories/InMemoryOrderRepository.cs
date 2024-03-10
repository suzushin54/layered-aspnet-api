using src.Ordering.Domain.Entities;
using src.Ordering.Domain.RepositoryInterfaces;

namespace src.Ordering.Infrastructure.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private List<Order>? _orders = new List<Order>();
    
    public IEnumerable<Order>? GetOrders()
    {
        return _orders;
    }
    
    public void Save(Order order)
    {
        _orders?.Add(order);
    }
}