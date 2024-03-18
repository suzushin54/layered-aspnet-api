using src.Monolith.Domain.Entities;
using src.Monolith.Domain.RepositoryInterfaces;

namespace src.Monolith.Infrastructure.Repositories;

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