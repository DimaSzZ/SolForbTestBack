using Domain.Interface;
using Domain.Interface.Filters;
using Domain.Models.Order;

namespace Infrastructure.Filters;

public class OrderFilter : IOrderFilter
{
    private IQueryable<Order> _orders;

    public OrderFilter(IQueryable<Order> orders)
    {
        _orders = orders;
    }
    public IOrderFilter DateOrderFilter(DateTime? lowDate, DateTime? highDate)
    {
        _orders = _orders switch
        {
            { } when lowDate != null && highDate != null =>
                _orders.Where(o => o.Date >= lowDate && o.Date <= highDate),
            { } when lowDate != null =>
                _orders.Where(o => o.Date >= lowDate),
            { } when highDate != null =>
                _orders.Where(o => o.Date <= highDate),
            
            _ => _orders.Where(o => o.Date >= DateTime.Now.AddMonths(-1))
        };
        return this;
    }

    public IOrderFilter NumberOrderFilter(string? number)
    {
        _orders = number switch
        {
            null => _orders,
            _ => _orders.Where(o => o.Number == number)
        };

        return this;
    }

    public IOrderFilter OrderItemNameFilter(string? name)
    {
        _orders = name switch
        {
            null => _orders,
            _ => _orders.Where(o => o.OrderItems.Any(oi => oi.Name == name))
        };

        return this;
    }

    public IOrderFilter UnitFilter(string? unit)
    {
        _orders = unit switch
        {
            null => _orders,
            _ => _orders.Where(o => o.OrderItems.Any(oi => oi.Unit == unit))
        };
        return this;
    }

    public IOrderFilter ProviderNameFilter(string? providerName)
    {
        _orders = providerName switch
        {
            null => _orders,
            _ => _orders.Where(o => o.Provider.Name == providerName)
        };

        return this;
    }

    public IOrderFilter ProviderIdFilter(int? providerId)
    {
        _orders = providerId switch
        {
            null => _orders,
            _ => _orders.Where(o => o.ProviderId == providerId)
        };
        return this;
    }

    public IQueryable<Order> GetFilteredOrders()
    {
        return _orders;
    }
}