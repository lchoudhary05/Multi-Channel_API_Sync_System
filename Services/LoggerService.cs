using System;

namespace MultiChannelSalesSync.Services
{
    public class LoggerService
    {
        public void LogInfo(string message, object data = null)
        {
            Console.WriteLine($"[INFO] {DateTime.UtcNow:o} - {message} {data ?? ""}");
        }

        public void LogError(string message, Exception ex)
        {
            Console.WriteLine($"[ERROR] {DateTime.UtcNow:o} - {message} {ex}");
        }
    }
} 