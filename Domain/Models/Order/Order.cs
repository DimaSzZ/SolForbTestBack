using Newtonsoft.Json;

namespace Domain.Models.Order
{
    public class Order
    {
        public Order(string number, DateTime date, int providerId)
        {
            Number = number;
            Date = date;
            ProviderId = providerId;
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }

        [JsonIgnore] public virtual Provider.Provider Provider { get; set; }
        [JsonIgnore] public virtual IEnumerable<OrderItem.OrderItem> OrderItems { get; set; }
        
    }
}

