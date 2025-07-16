using System.Collections.Generic;

namespace MultiChannelSalesSync.Services
{
    public class InventoryService
    {
        private static Dictionary<string, int> stock = new Dictionary<string, int>
        {
            { "SKU123", 10 },
            { "SKU456", 5 },
            { "SKU789", 8 }
        };

        public void UpdateStock(string sku, int quantity)
        {
            if (stock.ContainsKey(sku))
                stock[sku] -= quantity;
        }

        public int? GetStock(string sku)
        {
            return stock.ContainsKey(sku) ? stock[sku] : (int?)null;
        }
    }
} 