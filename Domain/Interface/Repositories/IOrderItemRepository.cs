using Domain.Models.OrderItem;

namespace Domain.Interface;

public interface IOrderItemRepository
{
    public Task SaveOrderItem(List<OrderItem> orderItem, int idOrder,CancellationToken cancellationToken);
    public Task DeleteOrderItem(int id,CancellationToken cancellationToken);
    public Task<List<OrderItem>> ShowAllOrderItems(CancellationToken cancellationToken);
    
    public Task<List<OrderItem>> ShowSingleOrderItems(int orderId, CancellationToken cancellationToken);
}