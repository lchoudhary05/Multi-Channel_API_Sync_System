using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MultiChannelSalesSync.Interfaces;
using System.Linq;

namespace MultiChannelSalesSync.Services
{
    public class ScheduledSyncService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1); // Change as needed

        public ScheduledSyncService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var shopify = scope.ServiceProvider.GetRequiredService<IShopifyService>();
                    var amazon = scope.ServiceProvider.GetRequiredService<IAmazonService>();
                    var inventory = scope.ServiceProvider.GetRequiredService<IInventoryService>();
                    var accounting = scope.ServiceProvider.GetRequiredService<IAccountingService>();
                    var logger = scope.ServiceProvider.GetRequiredService<ILoggerService>();

                    try
                    {
                        logger.LogInfo("Scheduled sync process started");
                        var shopifyOrders = shopify.FetchOrders();
                        var amazonOrders = amazon.FetchOrders();
                        var allOrders = shopifyOrders.Concat(amazonOrders);

                        foreach (var order in allOrders)
                        {
                            logger.LogInfo("Processing order", order.OrderId);
                            if (order.Items != null)
                            {
                                foreach (var item in order.Items)
                                {
                                    inventory.UpdateStock(item.Sku, item.Quantity);
                                    logger.LogInfo($"Updated stock for SKU {item.Sku}", $"- {item.Quantity}");
                                }
                            }
                            accounting.RecordTransaction(order);
                            logger.LogInfo("Recorded transaction", order.OrderId);
                        }
                        logger.LogInfo("Scheduled sync process completed");
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error during scheduled sync process", ex);
                    }
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
} 