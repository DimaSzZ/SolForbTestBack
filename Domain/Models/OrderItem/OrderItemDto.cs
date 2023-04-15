﻿namespace Domain.Models.OrderItem;

public class OrderItemDto
{
    public int ?Id { get; set; }

    public string Name { get; set; }

    public decimal Quantity { get; set; }

    public string Unit { get; set; }
    
    public int OrderId { get; set; }
}