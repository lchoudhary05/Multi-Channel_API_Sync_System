using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MultiChannelSalesSync.Services
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDbSettings");
            var client = new MongoClient(settings["ConnectionString"]);
            _database = client.GetDatabase(settings["DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            _database.GetCollection<T>(name);
    }
} 