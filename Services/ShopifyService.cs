using System;
using System.Collections.Generic;
using MultiChannelSalesSync.Models;

namespace MultiChannelSalesSync.Services
{
    public class ShopifyService
    {
        public List<Order> FetchOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = "shopify-1001",
                    Items = new List<OrderItem>
                    {
                        new OrderItem { Sku = "SKU123", Quantity = 2 },
                        new OrderItem { Sku = "SKU456", Quantity = 1 }
                    },
                    Total = 150.00m,
                    Customer = "Alice Smith",
                    CreatedAt = DateTime.UtcNow.AddHours(-2)
                }
            };
        }
    }
} 