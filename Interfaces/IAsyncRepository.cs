using System.Threading.Tasks;
namespace SharpRepository.Interfaces
{
    public interface IAsyncRepository<T, ID> : IAsyncPaginationRepository<T,ID>, IAsyncReadRepository<T, ID>, IAsyncWriteRepository<T> where T : class
    {
        Task<int> SaveAsync();
    }
}