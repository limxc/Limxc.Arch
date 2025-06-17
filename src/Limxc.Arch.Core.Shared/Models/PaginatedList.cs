using System;
using System.Collections.Generic;
using System.Linq;

namespace Limxc.Arch.Core.Shared.Models
{
    public class PaginatedList<T>
    {
        public PaginatedList(IList<T> items, int totalCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
            Items = items;
        }

        public IList<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static PaginatedList<T> CreateAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize
        )
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
