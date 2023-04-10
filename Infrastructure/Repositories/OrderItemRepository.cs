using Domain.Interface;
using Domain.Models.OrderItem;
using Infrastructure.Parsistence.PgDbContext;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    public OrderItemRepository(PgDbContext ctx)
    {
        _ctx = ctx;
    }

    private readonly PgDbContext _ctx;
    
    public async Task SaveOrderItem(List<OrderItem> orderItem,int orderId, CancellationToken cancellationToken)
    {
        var order = await _ctx.Orders.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
        if(orderItem.Any(x => x.Name == order.Number)) throw new Exception("OrderItem.Name не может быть равен Order.Number (ограничение предметной области).");
        if (order != null)
        {
            order.OrderItems = orderItem.ToList();
            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteOrderItem(int id, CancellationToken cancellationToken)
    {
        var item = await _ctx.OrderItems.FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
        if (item != null)
        {
            _ctx.OrderItems.Remove(item);
            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }

    public Task<List<OrderItem>> ShowAllOrderItems(CancellationToken cancellationToken)
    {
        return _ctx.OrderItems.ToListAsync(cancellationToken);
    }

    public async Task<List<OrderItem>> ShowSingleOrderItems(int orderId, CancellationToken cancellationToken)
    {
        return await _ctx.OrderItems.Where(items => items.OrderId == orderId).ToListAsync(cancellationToken);
    }
}