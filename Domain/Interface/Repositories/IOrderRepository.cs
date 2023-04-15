using Domain.Models.Order;

namespace Domain.Interface.Repositories;

public interface IOrderRepository
{
    public Task<int> SaveOrder(Order order,CancellationToken cancellationToken);
    public Task DeleteOrder(int id,CancellationToken cancellationToken);
    public Task<List<Order>> ShowAllOrders(CancellationToken cancellationToken);
    public Task<Order?> OneById(int id, CancellationToken cancellationToken);

    public Task<List<Order>> GetOrdersByFilter(
        string? number,
        DateTime? lowDate,
        DateTime? highDate, 
        int? providerId,
        string? productName,
        string? unit,
        string? providerName
    );
}