using System.Collections.Generic;
using MultiChannelSalesSync.Models;

namespace MultiChannelSalesSync.Interfaces
{
    public interface IShopifyService
    {
        List<Order> FetchOrders();
    }
} 