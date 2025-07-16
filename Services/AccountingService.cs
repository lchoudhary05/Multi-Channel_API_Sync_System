using System;
using System.Collections.Generic;
using MultiChannelSalesSync.Models;

namespace MultiChannelSalesSync.Services
{
    public class AccountingService
    {
        private static List<Transaction> transactions = new List<Transaction>();

        public void RecordTransaction(Order order)
        {
            transactions.Add(new Transaction
            {
                OrderId = order.Id,
                Total = order.Total,
                Customer = order.Customer,
                RecordedAt = DateTime.UtcNow
            });
        }

        public List<Transaction> GetTransactions() => transactions;
    }
} 