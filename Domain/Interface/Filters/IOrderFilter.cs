using Domain.Models.Order;

namespace Domain.Interface.Filters;

public interface IOrderFilter
{
    
    public IOrderFilter DateOrderFilter(DateTime? lowDate,DateTime? highDate);
    
    public IOrderFilter NumberOrderFilter( string? number);
    
    public IOrderFilter OrderItemNameFilter( string? name);
    
    public IOrderFilter UnitFilter(string? unit);
    
    public IOrderFilter ProviderNameFilter(string? providerName);
    
    public IOrderFilter ProviderIdFilter(int? providerId);
    
    public  IQueryable<Order> GetFilteredOrders();
    
}
