using MongoDB.Driver;
using MultiChannelSalesSync.Models;
using System;

namespace MultiChannelSalesSync.Services
{
    public class LoggerService
    {
        private readonly IMongoCollection<LogEntry> _logs;

        public LoggerService(MongoDbContext context)
        {
            _logs = context.GetCollection<LogEntry>("logs");
        }

        public void LogInfo(string message, object data = null)
        {
            var entry = new LogEntry
            {
                Level = "Info",
                Message = message,
                Data = data?.ToString(),
                Timestamp = DateTime.UtcNow
            };
            _logs.InsertOne(entry);
            Console.WriteLine($"[INFO] {entry.Timestamp:o} - {message} {entry.Data ?? ""}");
        }

        public void LogError(string message, Exception ex)
        {
            var entry = new LogEntry
            {
                Level = "Error",
                Message = message,
                Data = ex.ToString(),
                Timestamp = DateTime.UtcNow
            };
            _logs.InsertOne(entry);
            Console.WriteLine($"[ERROR] {entry.Timestamp:o} - {message} {ex}");
        }
    }
} 