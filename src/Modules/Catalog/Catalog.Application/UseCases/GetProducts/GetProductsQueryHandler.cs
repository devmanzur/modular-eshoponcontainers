using System.Threading;
using System.Threading.Tasks;
using Catalog.Core.Models;
using Catalog.Core.Repositories;
using CrossCuttingConcerns.Application.CQRS;
using CrossCuttingConcerns.Core.Features.Paging;

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
            var products = await _productsRepository.GetProducts(request.Query.PageSize, request.Query.Skip());
            var count = await _productsRepository.GetTotalCount();
            return new PagedList<Product>(products, request.Query,count);
        }
    }
}