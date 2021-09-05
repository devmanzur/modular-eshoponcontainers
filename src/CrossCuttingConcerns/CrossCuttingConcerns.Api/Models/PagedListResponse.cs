using System.Collections.Generic;
using CrossCuttingConcerns.Core.Features.Paging;

namespace CrossCuttingConcerns.Api.Models
{
    public class PagedListResponse<T>
    {
        public PagingMetaData Meta { get; set; }

        public List<T> Items { get; set; }
    }
}