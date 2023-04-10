using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain.Models.Provider;

public class Provider
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore] public virtual IEnumerable<Order.Order> Orders { get; set; }
    
}