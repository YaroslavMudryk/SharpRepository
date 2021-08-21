using SharpRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace SharpRepository.Interfaces
{
    public interface IAsyncRepository<T, ID> : IAsyncReadRepository<T, ID>, IAsyncWriteRepository<T> where T : class
    {
        Task<int> SaveAsync();
    }

    public interface IAsyncPaginationRepository<T>
    {
        PaginationList<T> GetPaginationListAsync(int offset, int count, bool disableTracking = true);
    }

    public interface IAsyncReadRepository<T, ID>
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

    public interface IAsyncWriteRepository<T>
    {
        Task<T> InsertOneAsync(T entity, bool withSave = false);

        Task<List<T>> InsertListAsync(List<T> entities, bool withSave = false);

        Task<T> UpdateOneAsync(T entity, bool withSave = false);

        Task<List<T>> UpdateListAsync(List<T> entities, bool withSave = false);

        Task<T> RemoveOneAsync(T entity, bool withSave = false);

        Task<List<T>> RemoveListAsync(List<T> entities, bool withSave = false);
    }
}