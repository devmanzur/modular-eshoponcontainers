using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.UseCases.GetProducts;
using Catalog.Core.Models;
using CrossCuttingConcerns.Core.Features.Paging;
using FluentAssertions;
using Moq;
using Xunit;

namespace Catalog.Core.Tests.Application.UseCases
{
    public partial class UseCasesTests
    {
        [Fact]
        public async Task Given_valid_page_size_exact_number_of_items_is_returned()
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
            var expectedMeta = new PagingMetaData()
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int) Math.Ceiling(totalRepositoryItemCount / (double) pageSize)
            };

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
            actualResult.Meta.Should().Be(expectedMeta);
        }

        [Fact]
        public async Task Given_repository_returns_no_data_items_is_empty_total_page_count_is_zero()
        {
            //given
            var pageSize = GetValidPageSize();
            var pageNumber = GetValidPageNumber();
            List<Product> repositoryProducts = null;
            var pagingQuery = new PagingQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var expectedMeta = new PagingMetaData()
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = 0
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
            actualResult.Items.Should().NotBeNull();
            actualResult.Items.Should().BeEmpty();
            actualResult.Meta.Should().Be(expectedMeta);
        }

        [Fact]
        public async Task Given_page_size_over_max_limit_default_maximum_number_of_items_is_returned()
        {
            //given
            var pageSize = GetPageSizeOverMaxLimit();
            var pageNumber = GetValidPageNumber();
            var repositoryProducts = CreateRandomRepositoryProducts(MaxPageSize);
            var totalRepositoryItemCount = pageSize * 5;
            var pagingQuery = new PagingQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var expectedMeta = new PagingMetaData()
            {
                CurrentPage = pageNumber,
                PageSize = MaxPageSize,
                TotalPages = (int) Math.Ceiling(totalRepositoryItemCount / (double) MaxPageSize)
            };

            _productsRepositoryMoq.Setup(x => x.GetProducts(pagingQuery.PageSize, pagingQuery.Offset()))
                .ReturnsAsync(repositoryProducts);

            _productsRepositoryMoq.Setup(x => x.GetTotalCount())
                .ReturnsAsync(totalRepositoryItemCount);

            var query = new GetProductsQuery(pagingQuery);
            var handler = new GetProductsQueryHandler(_productsRepositoryMoq.Object);

            //when
            var actualResult = await handler.Handle(query, new CancellationToken());

            //then
            actualResult.Items.Count.Should().Be(MaxPageSize);
            actualResult.Meta.Should().Be(expectedMeta);
        }

        [Fact]
        public async Task Given_page_size_below_min_limit_default_minimum_number_of_items_is_returned()
        {
            //given
            var pageSize = GetPageSizeBelowMinLimit();
            var pageNumber = GetValidPageNumber();
            var repositoryProducts = CreateRandomRepositoryProducts(MinPageSize);
            var pagingQuery = new PagingQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var totalRepositoryItemCount = pageSize * 5;

            var expectedMeta = new PagingMetaData()
            {
                CurrentPage = pageNumber,
                PageSize = MinPageSize,
                TotalPages = (int) Math.Ceiling(totalRepositoryItemCount / (double) MinPageSize)
            };

            _productsRepositoryMoq.Setup(x => x.GetProducts(pagingQuery.PageSize, pagingQuery.Offset()))
                .ReturnsAsync(repositoryProducts);

            _productsRepositoryMoq.Setup(x => x.GetTotalCount())
                .ReturnsAsync(totalRepositoryItemCount);

            var query = new GetProductsQuery(pagingQuery);
            var handler = new GetProductsQueryHandler(_productsRepositoryMoq.Object);

            //when
            var actualResult = await handler.Handle(query, new CancellationToken());

            //then
            actualResult.Items.Count.Should().Be(MinPageSize);
            actualResult.Meta.Should().Be(expectedMeta);
        }

        [Fact]
        public async Task Given_page_number_below_min_limit_default_page_number_is_returned()
        {
            //given
            var pageSize = GetValidPageSize();
            var pageNumber = GetPageNumberBelowMinLimit();
            var repositoryProducts = CreateRandomRepositoryProducts(pageSize);
            var pagingQuery = new PagingQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var totalRepositoryItemCount = pageSize * 5;

            var expectedMeta = new PagingMetaData()
            {
                CurrentPage = MinPageNumber,
                PageSize = pageSize,
                TotalPages = (int) Math.Ceiling(totalRepositoryItemCount / (double) pageSize)
            };

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
            actualResult.Meta.Should().Be(expectedMeta);
        }
    }
}