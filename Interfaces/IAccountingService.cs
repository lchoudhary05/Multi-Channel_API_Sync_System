using System.Collections.Generic;
using MultiChannelSalesSync.Models;

namespace MultiChannelSalesSync.Interfaces
{
    public interface IAccountingService
    {
        void RecordTransaction(Order order);
        List<Transaction> GetTransactions();
    }
} 