using Xunit;

namespace Manzur.eShopOnContainers.API.AcceptanceTests.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<EShopApiBroker>
    {
    }
}