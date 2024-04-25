public interface IOrderRepository
{
    Order GetOrderByDest(string orderDestination, string orderOrigin);
    void AddOrder(Order order); 
    void DeleteOrder(int orderId);
} 