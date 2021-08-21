using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharpRepository.Implementations;
using SharpRepository.Interfaces;

namespace SharpRepository.Extensions
{
    public static class SharpRepExtension
    {
        public static IServiceCollection AddSharpRepository<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddDbContext<DbContext>();
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(AsyncRepository<,>));
            return services;
        }
    }
}