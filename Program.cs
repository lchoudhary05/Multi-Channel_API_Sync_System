using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiChannelSalesSync.Services;
using MultiChannelSalesSync.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<IShopifyService, ShopifyService>();
builder.Services.AddSingleton<IAmazonService, AmazonService>();
builder.Services.AddSingleton<IInventoryService, InventoryService>();
builder.Services.AddSingleton<IAccountingService, AccountingService>();
builder.Services.AddSingleton<ILoggerService, LoggerService>();
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddControllers();
builder.Services.AddHostedService<ScheduledSyncService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
