using System;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.UseCases.GetProducts;
using CrossCuttingConcerns.Core.Features.Paging;
using FluentAssertions;
using Moq;
using Xunit;

namespace Catalog.Core.Tests.Application.UseCases
{
    public partial class UseCasesTests
    {
        [Fact]
        public async Task Given_page_size_within_max_limit_exact_number_of_items_is_returned()
        {
            //given
            var pageSize = GetValidPageSize();
            var pageNumber = GetValidPageNumber();
            var repositoryProducts = CreateRandomRepositoryProducts(pageSize);
            var pagingQuery = new PagingQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var totalRepositoryItemCount = pageSize * 5;

            _productsRepositoryMoq.Setup(x => x.GetProducts(pagingQuery.PageSize, pagingQuery.Offset()))
                .ReturnsAsync(repositoryProducts);

            _productsRepositoryMoq.Setup(x => x.GetTotalCount())
                .ReturnsAsync(totalRepositoryItemCount);

            var query = new GetProductsQuery(pagingQuery);
            var handler = new GetProductsQueryHandler(_productsRepositoryMoq.Object);

            //when
            var actualResult = await handler.Handle(query, new CancellationToken());

            //then
            actualResult.Items.Count.Should().Be(pageSize);
            actualResult.Meta.CurrentPage.Should().Be(pageNumber);
            actualResult.Meta.PageSize.Should().Be(pageSize);
            actualResult.Meta.TotalPages.Should().Be((int) Math.Ceiling(totalRepositoryItemCount / (double) pageSize));
        }

        [Fact]
        public async Task Given_page_size_exceeds_max_limit_default_max_number_of_items_is_returned()
        {
            //given
            int maxPageSize = 30;
            var pageSize = GetOverLimitPageSize();
            var pageNumber = GetValidPageNumber();
            var repositoryProducts = CreateRandomRepositoryProducts(maxPageSize);
            var pagingQuery = new PagingQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var totalRepositoryItemCount = pageSize * 5;

            _productsRepositoryMoq.Setup(x => x.GetProducts(pagingQuery.PageSize, pagingQuery.Offset()))
                .ReturnsAsync(repositoryProducts);

            _productsRepositoryMoq.Setup(x => x.GetTotalCount())
                .ReturnsAsync(totalRepositoryItemCount);

            var query = new GetProductsQuery(pagingQuery);
            var handler = new GetProductsQueryHandler(_productsRepositoryMoq.Object);

            //when
            var actualResult = await handler.Handle(query, new CancellationToken());

            //then
            actualResult.Items.Count.Should().Be(maxPageSize);
            actualResult.Meta.CurrentPage.Should().Be(pageNumber);
            actualResult.Meta.PageSize.Should().Be(maxPageSize);
            actualResult.Meta.TotalPages.Should().Be((int) Math.Ceiling(totalRepositoryItemCount / (double) maxPageSize));
        }
    }
}