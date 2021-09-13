using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Core.Models;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Persistence;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class MongoProductsRepository : IProductsRepository
    {
        private readonly MongoDbContext _mongoDbContext;

        public MongoProductsRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public Task<List<Product>> GetProducts(int size, int offset)
        {
            return _mongoDbContext.Products.Find(x => x.Name != null).Skip(offset).Limit(size).ToListAsync();
        }

        public Task<long> GetTotalCount()
        {
            return _mongoDbContext.Products.EstimatedDocumentCountAsync();
        }
    }
}