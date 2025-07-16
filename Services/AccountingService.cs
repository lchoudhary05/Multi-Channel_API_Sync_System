using MongoDB.Driver;
using MultiChannelSalesSync.Models;
using System;
using System.Collections.Generic;

namespace MultiChannelSalesSync.Services
{
    public class AccountingService
    {
        private readonly IMongoCollection<Transaction> _transactions;

        public AccountingService(MongoDbContext context)
        {
            _transactions = context.GetCollection<Transaction>("accounting");
        }

        public void RecordTransaction(Order order)
        {
            var transaction = new Transaction
            {
                OrderId = order.OrderId,
                Total = order.TotalAmount,
                Customer = order.CustomerName,
                RecordedAt = DateTime.UtcNow
            };
            _transactions.InsertOne(transaction);
        }

        public List<Transaction> GetTransactions() => _transactions.Find(_ => true).ToList();
    }
} 