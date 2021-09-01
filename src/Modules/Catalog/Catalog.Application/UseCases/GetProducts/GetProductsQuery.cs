using Catalog.Core.Models;
using CrossCuttingConcerns.Application.CQRS;
using CrossCuttingConcerns.Core.Features.Paging;

namespace Catalog.Application.UseCases.GetProducts
{
    public class GetProductsQuery : IQuery<PagedList<Product>>
    {
        public PagingQuery Query { get; }

        public GetProductsQuery(PagingQuery query)
        {
            Query = query;
        }
    }
}