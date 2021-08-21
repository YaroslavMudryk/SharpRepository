using SharpRepository.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharpRepository.Interfaces
{
    public interface IAsyncPaginationRepository<T>
    {
        Task<PaginationList<T>> GetPaginationListAsync(int offset, int count, bool disableTracking = true);

        Task<PaginationList<T>> GetPaginationListAsync(Expression<Func<T, bool>> predicate, int offset = 0, int count = 20, bool disableTracking = true);
    }
}