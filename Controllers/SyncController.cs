using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MultiChannelSalesSync.Interfaces;

namespace MultiChannelSalesSync.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SyncController : ControllerBase
    {
        private readonly IShopifyService _shopify;
        private readonly IAmazonService _amazon;
        private readonly IInventoryService _inventory;
        private readonly IAccountingService _accounting;
        private readonly ILoggerService _logger;

        public SyncController(
            IShopifyService shopify,
            IAmazonService amazon,
            IInventoryService inventory,
            IAccountingService accounting,
            ILoggerService logger)
        {
            _shopify = shopify;
            _amazon = amazon;
            _inventory = inventory;
            _accounting = accounting;
            _logger = logger;
        }

        [HttpPost("sync")]
        public IActionResult Sync()
        {
            try
            {
                _logger.LogInfo("Starting sync process");
                var shopifyOrders = _shopify.FetchOrders();
                var amazonOrders = _amazon.FetchOrders();
                var allOrders = shopifyOrders.Concat(amazonOrders);

                foreach (var order in allOrders)
                {
                    _logger.LogInfo("Processing order", order.Id);
                    foreach (var item in order.Items)
                    {
                        _inventory.UpdateStock(item.Sku, item.Quantity);
                        _logger.LogInfo($"Updated stock for SKU {item.Sku}", $"- {item.Quantity}");
                    }
                    _accounting.RecordTransaction(order);
                    _logger.LogInfo("Recorded transaction", order.Id);
                }
                _logger.LogInfo("Sync process completed");
                return Ok("Sync completed");
            }
            catch (System.Exception ex)
            {
                _logger.LogError("Error during sync process", ex);
                return StatusCode(500, "Error during sync");
            }
        }
    }
} 