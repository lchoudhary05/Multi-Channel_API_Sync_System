using System;
using System.Collections.Generic;

namespace MultiChannelSalesSync.Models
{
    public class Order
    {
        public string Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Total { get; set; }
        public string Customer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 