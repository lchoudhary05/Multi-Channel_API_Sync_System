using MongoDB.Driver;
using MultiChannelSalesSync.Models;
using System.Collections.Generic;

namespace MultiChannelSalesSync.Services
{
    public class ShopifyService : IShopifyService
    {
        private readonly IMongoCollection<Order> _shopifyOrders;

        public ShopifyService(MongoDbContext context)
        {
            _shopifyOrders = context.GetCollection<Order>("shopifyOrders");
        }

        public List<Order> FetchOrders()
        {
            return _shopifyOrders.Find(_ => true).ToList();
        }
    }
} 