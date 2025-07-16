using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MultiChannelSalesSync.Models
{
    public class LogEntry
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Level { get; set; } // "Info" or "Error"
        public string Message { get; set; }
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }
    }
} 