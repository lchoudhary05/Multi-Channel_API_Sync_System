using System;

namespace MultiChannelSalesSync.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string message, object? data = null);
        void LogError(string message, Exception ex);
    }
} 