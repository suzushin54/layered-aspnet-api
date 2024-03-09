using src.Domain.Entities;
using src.Domain.RepositoryInterfaces;

namespace src.DataStore.Repositories;

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