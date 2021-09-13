using Catalog.Core.Models;
using Catalog.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        
        public MongoDbContext(IOptions<MongoDbConfiguration> configuration)
        {
            var client = new MongoClient(configuration.Value.ConnectionString);
            _database = client.GetDatabase(configuration.Value.DatabaseName);
        }
        
        public IMongoCollection<Product> Products
            => _database.GetCollection<Product>("Products");
    }
}