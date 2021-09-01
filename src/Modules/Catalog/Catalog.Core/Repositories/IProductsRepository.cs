using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Core.Models;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Features.Paging;

namespace Catalog.Core.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetItems(Page page);
    }
}