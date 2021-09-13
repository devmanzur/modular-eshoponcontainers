using Catalog.Application.Utils;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Mappings;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.Utils
{
    public static class DependencyExtensions
    {
        public static void RegisterCatalogModule(this IServiceCollection services)
        {
            services.AddApplicationMediatrBindings();
            services.AddScoped<IProductsRepository, MongoProductsRepository>();
            services.AddScoped<MongoDbContext>();
            services.ApplyDocumentMappings();
        }
    }
}