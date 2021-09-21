using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Catalog.Core.Models;
using CSharpFunctionalExtensions;
using Manzur.eShopOnContainers.API.AcceptanceTests.Brokers;
using Manzur.eShopOnContainers.API.Models;
using Xunit;

namespace Manzur.eShopOnContainers.API.AcceptanceTests.APIs
{
    [Collection(nameof(ApiTestCollection))]
    public partial class ProductsApiTests
    {
        private readonly EShopApiBroker eShopApiBroker;
        private readonly Fixture _fixture;
        private const int MaxPageSize = 20;
        private const int MinPageSize = 10;
        private const int MinPageNumber = 1;

        public ProductsApiTests(EShopApiBroker eShopApiBroker)
        {
            this.eShopApiBroker = eShopApiBroker;
            _fixture = new Fixture();
        }


        private int GetRandomPageSize()
        {
            return (new Random()).Next(MinPageSize, MaxPageSize);
        }

        private int GetFirstPage()
        {
            return 1;
        }

        private static int GetRandomNumber() => (new Random()).Next(2, 10);


        private List<Product> CreateRandomRepositoryProducts(int pageSize)
        {
            return _fixture.CreateMany<Product>(pageSize).ToList();
        }

        private ProductCreateDto CreateRandomProduct()
        {
            return _fixture.Build<ProductCreateDto>()
                .With(x => x.ImageUrl, $"{Guid.NewGuid()}.png").Create();
        }

        private async Task<ProductDto> PostRandomProduct()
        {
            ProductCreateDto randomProduct = CreateRandomProduct();
            var createProduct = await this.eShopApiBroker.PostProductAsync(randomProduct);

            if (createProduct.IsSuccess)
            {
                return createProduct.Value.Body;
            }

            return null;
        }

        private async Task<Result> DeleteProductById(Guid id)
        {
            var deleteProduct = await this.eShopApiBroker.DeleteProductAsync(id);

            if (deleteProduct.IsSuccess)
            {
                return Result.Success();
            }

            return Result.Failure(deleteProduct.Error);
        }
    }
}