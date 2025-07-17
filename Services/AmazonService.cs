using MongoDB.Driver;
using MultiChannelSalesSync.Models;
using System.Collections.Generic;

namespace MultiChannelSalesSync.Services
{
    public class AmazonService : IAmazonService
    {
        private readonly IMongoCollection<Order> _amazonOrders;

        public AmazonService(MongoDbContext context)
        {
            _amazonOrders = context.GetCollection<Order>("amazonOrders");
        }

        public List<Order> FetchOrders()
        {
            return _amazonOrders.Find(_ => true).ToList();
        }
    }
} 