using Domain.Interface;
using Domain.Interface.Repositories;
using Domain.Models.Order;
using Infrastructure.Filters;
using Infrastructure.Parsistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository :  IOrderRepository
{
    public OrderRepository(PgDbContext ctx)
    {
        _ctx = ctx;
    }

    private readonly PgDbContext _ctx;
    
    public async Task<int> SaveOrder(Order order, CancellationToken cancellationToken)
    {
        if(_ctx.OrderItems.Any(x => x.Name == order.Number)) throw new Exception("OrderItem.Name не может быть равен Order.Number (ограничение предметной области).");
        if (!_ctx.Providers.Any(x => x.Id == order.ProviderId)) throw new Exception("Такого провайдера не существует");
        if (_ctx.Orders.Contains(order))
        {
            _ctx.Update(order);
        }
        else
            await _ctx.Orders.AddAsync(order, cancellationToken);

        await _ctx.SaveChangesAsync(cancellationToken);
        return order.Id;
    }

    public async Task DeleteOrder(int id, CancellationToken cancellationToken)
    {
        var order = await _ctx.Orders.Where(order => order.Id == id).FirstOrDefaultAsync(cancellationToken);
        _ctx.Remove(order);
        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public Task<List<Order>> ShowAllOrders(CancellationToken cancellationToken)
    {
        return _ctx.Orders.ToListAsync(cancellationToken);
    }

    public async Task<Order?> OneById(int id, CancellationToken cancellationToken)
    {
        return await _ctx.Orders
            .Where(ads => ads.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Order>> GetOrdersByFilter(
        string? number, 
        DateTime? lowDate, 
        DateTime? highDate, 
        int? providerId, 
        string? productName,
        string? unit, 
        string? providerName
    )
    {
        return await new OrderFilter(_ctx.Orders)
            .DateOrderFilter(lowDate, highDate)
            .NumberOrderFilter(number)
            .OrderItemNameFilter(productName)
            .UnitFilter(unit)
            .ProviderNameFilter(providerName)
            .ProviderIdFilter(providerId)
            .GetFilteredOrders()
            .ToListAsync();
    }
}