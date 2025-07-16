using System;
using System.Collections.Generic;
using MultiChannelSalesSync.Models;

namespace MultiChannelSalesSync.Services
{
    public class AmazonService
    {
        public List<Order> FetchOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = "amazon-2001",
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Sku = "SKU123", Quantity = 1 },
                        new OrderItem { Sku = "SKU789", Quantity = 3 }
                    },
                    Total = 220.00m,
                    Customer = "Bob Johnson",
                    CreatedAt = DateTime.UtcNow.AddHours(-1)
                }
            };
        }
    }
} 