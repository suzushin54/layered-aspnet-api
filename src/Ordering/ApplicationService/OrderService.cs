using src.Ordering.ApplicationService.Dto;
using src.Ordering.Domain.RepositoryInterfaces;
using src.Ordering.Domain.Entities;

namespace src.Ordering.ApplicationService;

public interface IOrderService
{
    IEnumerable<Order>? GetOrders();
    void CreateOrder(CreateOrderDto createOrderDto);
}

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IEnumerable<Order>? GetOrders()
    {
        return _orderRepository.GetOrders();
    }
    
    public void CreateOrder(CreateOrderDto createOrderDto)
    {
        var orderProducts = createOrderDto.OrderProducts.Select(
            op => new OrderProduct(op.ProductId, op.Quantity, op.Price)).ToList();

        var order = new Order(createOrderDto.TotalPrice, orderProducts, createOrderDto.ShippingAddress);

        _orderRepository.Save(order);
    }
}