using Catalog.Core.Enums;
using Catalog.Core.Models;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Catalog.Infrastructure.Mappings
{
    public static class DomainToDocumentMappings
    {
        public static void ApplyDocumentMappings(this IServiceCollection services)
        {
            BsonClassMap.RegisterClassMap<BaseEntity>(x =>
            {
                x.MapIdMember(x => x.Id).SetIdGenerator(CombGuidGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<Price>(p =>
            {
                p.AutoMap();
                p.MapField(x => x.Currency).SetSerializer(new EnumSerializer<Currency>(BsonType.String));
            });

            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();
                cm.MapField("_attributes").SetElementName("Attributes");
            });
        }
    }
}