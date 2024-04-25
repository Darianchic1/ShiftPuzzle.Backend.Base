
public class OrderManager : IOrderManager
{
    private IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }   
    public void AddOrder(Order order)
    { 
        _orderRepository.AddOrder(order);
    }

    public Order GetOrderByDest(string orderDestination, string orderOrigin)
    { 
        return _orderRepository.GetOrderByDest(orderDestination, orderOrigin);
    }

    public void DeleteOrder(int orderId)
    { 
        _orderRepository.DeleteOrder(orderId);
    } 
}
