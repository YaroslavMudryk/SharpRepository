using System.Collections.Generic;
using System.Threading.Tasks;
namespace SharpRepository.Interfaces
{
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