using Newtonsoft.Json;

namespace Domain.Models.OrderItem;

public class OrderItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public decimal Quantity { get; set; }
    
    public string Unit { get; set; }
    
    public int OrderId { get; set; }
    [JsonIgnore] public Order.Order Order { get; set; }
    
}