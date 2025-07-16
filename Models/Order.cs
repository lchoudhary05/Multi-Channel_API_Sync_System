using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MultiChannelSalesSync.Models
{
    public class Order
    {   [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } // MongoDB document ID
        public string OrderId { get; set; } // e.g., "MGK12345678"
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentStatus { get; set; }
        public string FulfillmentStatus { get; set; }
    }
} 