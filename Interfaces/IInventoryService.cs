namespace MultiChannelSalesSync.Interfaces
{
    public interface IInventoryService
    {
        void UpdateStock(string sku, int quantity);
        int? GetStock(string sku);
    }
} 