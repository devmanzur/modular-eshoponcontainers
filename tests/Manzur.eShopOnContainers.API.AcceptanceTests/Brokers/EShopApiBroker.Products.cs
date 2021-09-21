using System;
using System.Net.Http;
using System.Threading.Tasks;
using CrossCuttingConcerns.Api.Models;
using CSharpFunctionalExtensions;
using Manzur.eShopOnContainers.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manzur.eShopOnContainers.API.AcceptanceTests.Brokers
{
    public partial class EShopApiBroker
    {
        private const string ProductsRelativeUrl = "api/v1/products";

        public Task<Envelope<PagedListResponse<ProductDto>>> GetProductsAsync(int pageNumber, int pageSize) =>
            this.Get<Envelope<PagedListResponse<ProductDto>>>(
                $"{ProductsRelativeUrl}?pageSize={pageSize}&pageNumber={pageNumber}");

        public Task<Result<Envelope<ProductDto>>> PostProductAsync(ProductCreateDto dto) =>
            this.Post<ProductCreateDto, Envelope<ProductDto>>($"{ProductsRelativeUrl}/", dto);

        public Task<Result<Envelope>> DeleteProductAsync(Guid id) =>
            this.Delete<Envelope>($"{ProductsRelativeUrl}/{id}");
    }
}