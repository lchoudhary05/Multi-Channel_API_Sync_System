using System.Collections.Generic;
using MultiChannelSalesSync.Models;

namespace MultiChannelSalesSync.Interfaces
{
    public interface IAmazonService
    {
        List<Order> FetchOrders();
    }
} 