using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class PagedList<T>
    {
        public PagingMetaData Meta { get; set; }

        public List<T> Items { get; set; }

        public PagedList(List<T> items, PagingQuery query, int count)
        {
            Meta = new PagingMetaData
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageNumber,
                TotalPages = items == null ? 0 : (int) Math.Ceiling(count / (double) query.PageSize)
            };

            Items = items ?? new List<T>();
        }
    }
}