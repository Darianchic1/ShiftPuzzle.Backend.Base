public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }

    public void AddOrder(Order order)
    {
        _context.Order.Add(order);
        _context.SaveChanges();
    }

    public Order GetOrderByDest(string orderDestination, string orderOrigin)
    {
        return _context.Order.FirstOrDefault(o => o.Destination == orderDestination);
        return _context.Order.FirstOrDefault(o => o.Origin == orderOrigin);
    }

    public void DeleteOrder(int orderId)
    {   
        _context.Order.Where(o => o.ID == orderId).ToList().ForEach(t => _context.Order.Remove(o));
        _context.SaveChanges(); 
    }
}