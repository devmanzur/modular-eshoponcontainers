using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class PagedList<T>
    {
        public PagingMetaData Meta { get; private set; }

        public List<T> Items { get; private set; }

        public PagedList(Maybe<List<T>> items, PagingQuery query, long count)
        {
            Meta = new PagingMetaData
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageNumber,
                TotalPages = items.HasNoValue ? 0 : (int) Math.Ceiling(count / (double) query.PageSize)
            };

            Items = items.HasValue ? items.Value : new List<T>();
        }
    }
}