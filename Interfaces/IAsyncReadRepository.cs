using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace SharpRepository.Interfaces
{
    public interface IAsyncReadRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, bool disableTracking = true);

        Task<List<T>> GetListAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> order = null,
            bool isOrderBy = true,
            bool disableTracking = true);

        Task<T> GetByIdAsync(object id);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true);
    }
}