using System;


namespace MultiChannelSalesSync.Models
{
    public class Transaction
    {
        public string OrderId { get; set; }
        public decimal Total { get; set; }
        public string Customer { get; set; }
        public DateTime RecordedAt { get; set; }
    }
} 