using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Core.Models;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Persistence;
using CSharpFunctionalExtensions;
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

        public Task Create(Product product)
        {
            return _mongoDbContext.Products.InsertOneAsync(product);
        }

        public async Task<Result> Remove(Guid productId)
        {
            var remove = await _mongoDbContext.Products.DeleteOneAsync(x => x.Id == productId);
            return Result.SuccessIf(remove.IsAcknowledged, "Failed to remove product");
        }
    }
}