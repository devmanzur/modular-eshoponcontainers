using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class PagedList<T> : List<T>
    {
        public PagingMetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new PagingMetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int) Math.Ceiling(count / (double) pageSize)
            };

            AddRange(items.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }
    }
}