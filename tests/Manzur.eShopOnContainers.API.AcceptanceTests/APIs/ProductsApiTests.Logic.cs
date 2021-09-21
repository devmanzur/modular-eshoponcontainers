using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Core.Models;
using CrossCuttingConcerns.Api.Models;
using FluentAssertions;
using Manzur.eShopOnContainers.API.Models;
using Xunit;

namespace Manzur.eShopOnContainers.API.AcceptanceTests.APIs
{
    public partial class ProductsApiTests
    {
        [Fact]
        public async Task ShouldGetProductsAccordingToPageRequestAsync()
        {
            //given
            var randomProducts = new List<ProductDto>();
            var pageSize = GetRandomPageSize();
            var pageNumber = GetFirstPage();

            //setup
            for (int i = 0; i < pageSize; i++)
            {
                randomProducts.Add(await PostRandomProduct());
            }

            List<ProductDto> inputProducts = randomProducts;
            List<ProductDto> expectedProducts = inputProducts.ToList();

            // when
            Envelope<PagedListResponse<ProductDto>> response =
                await this.eShopApiBroker.GetProductsAsync(pageNumber,pageSize);
            var actualProducts = response.Body.Items;

            // then
            foreach (ProductDto expectedProduct in expectedProducts)
            {
                ProductDto actualProduct =
                    actualProducts.Single(p =>
                        p.Id == expectedProduct.Id);

                actualProduct.Should().BeEquivalentTo(expectedProduct);

                //tear down
                await this.eShopApiBroker.DeleteProductAsync(actualProduct.Id);
            }
        }
    }
}