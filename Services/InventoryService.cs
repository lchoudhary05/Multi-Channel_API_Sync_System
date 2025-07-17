using MongoDB.Driver;
using MultiChannelSalesSync.Models;

namespace MultiChannelSalesSync.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMongoCollection<InventoryItem> _inventory;

        public InventoryService(MongoDbContext context)
        {
            _inventory = context.GetCollection<InventoryItem>("inventory");
        }

        public void UpdateStock(string sku, int quantity)
        {
            var filter = Builders<InventoryItem>.Filter.Eq(i => i.Sku, sku);
            var update = Builders<InventoryItem>.Update.Inc(i => i.Quantity, -quantity);
            _inventory.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
        }

        public int? GetStock(string sku)
        {
            var item = _inventory.Find(i => i.Sku == sku).FirstOrDefault();
            return item?.Quantity;
        }
    }
} 