using System.Collections.Generic;
namespace SharpRepository.Models
{
    public class PaginationList<T>
    {
        public PaginationList(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
            CurrentCount = items.Count;
            var totalPages = totalCount / CurrentCount;
            TotalPages = totalPages % 10 == 0 ? totalPages : totalPages + 1;
        }

        public List<T> Items { get; }
        public int TotalCount { get; }
        public int CurrentCount { get; }
        public int TotalPages { get; }
        public int CurrentPage { get; }
    }
}