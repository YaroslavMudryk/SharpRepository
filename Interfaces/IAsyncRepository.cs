using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace SharpRepository.Interfaces
{
    public interface IAsyncRepository<T, DBContext> : IAsyncPaginationRepository<T>, IAsyncReadRepository<T>, IAsyncWriteRepository<T> where T : class where DBContext : DbContext
    {
        Task<int> SaveAsync();
    }
}