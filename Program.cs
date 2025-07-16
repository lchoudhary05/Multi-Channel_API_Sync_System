using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiChannelSalesSync.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<ShopifyService>();
builder.Services.AddSingleton<AmazonService>();
builder.Services.AddSingleton<InventoryService>();
builder.Services.AddSingleton<AccountingService>();
builder.Services.AddSingleton<LoggerService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
