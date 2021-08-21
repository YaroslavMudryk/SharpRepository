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
        }

        public List<T> Items { get; }
        public int TotalCount { get; }
        public int CurrentCount { get; }
    }
}