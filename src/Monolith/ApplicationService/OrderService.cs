using src.Monolith.ApplicationService.Dto;
using src.Monolith.Domain.RepositoryInterfaces;
using src.Monolith.Domain.Entities;

namespace src.Monolith.ApplicationService;

public interface IOrderService
{
    IEnumerable<Order>? GetOrders();
    void CreateOrder(CreateMonolithOrderDto createMonolithOrderDto);
}

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public IEnumerable<Order>? GetOrders()
    {
        return _orderRepository.GetOrders();
    }

    public void CreateOrder(CreateMonolithOrderDto createMonolithOrderDto)
    {
        var now = DateTime.Now;
        
        var orderProducts = createMonolithOrderDto.OrderProductIds.Select(
            id => _productRepository.GetProductById(id)).ToList();
        
        if (orderProducts.Count == 0)
        {
            throw new Exception("Order must have at least one product");
        }

        var order = new Order(0, orderProducts!, createMonolithOrderDto.ShippingAddress, now);

        _orderRepository.Save(order);
    }
}