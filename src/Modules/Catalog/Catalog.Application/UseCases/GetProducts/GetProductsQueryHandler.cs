using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Core.Models;
using Catalog.Core.Repositories;
using CrossCuttingConcerns.Application.CQRS;
using CrossCuttingConcerns.Core.Features.Paging;
using CSharpFunctionalExtensions;

namespace Catalog.Application.UseCases.GetProducts
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery,PagedList<Product>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductsQueryHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        
        public async Task<PagedList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            Maybe<List<Product>> products = await _productsRepository.GetProducts(request.Query.PageSize, request.Query.Offset());
            var count = products.HasValue? await _productsRepository.GetTotalCount() : 0;
            return new PagedList<Product>(products, request.Query,count);
        }
    }
}