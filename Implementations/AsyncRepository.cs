using Microsoft.EntityFrameworkCore;
using SharpRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace SharpRepository.Implementations
{
    public class AsyncRepository<T, ID> : IAsyncRepository<T, ID> where T : class
    {
        protected readonly DbContext _db;
        protected readonly DbSet<T> _dbSet;
        public AsyncRepository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }


        #region Reading

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool disableTracking = true)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (disableTracking)
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool isOrderBy = true, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            query = query.Where(predicate);

            if (isOrderBy)
                return await query.OrderBy(x => x).ToListAsync();
            return await query.OrderByDescending(x => x).ToListAsync();

        }

        #endregion

        #region Writing

        public async Task<List<T>> InsertListAsync(List<T> entities, bool withSave = false)
        {
            await _db.AddRangeAsync(entities);
            if (withSave)
                await SaveAsync();
            return entities;
        }

        public async Task<T> InsertOneAsync(T entity, bool withSave = false)
        {
            await _db.AddAsync(entity);
            if (withSave)
                await SaveAsync();
            return entity;
        }

        public async Task<List<T>> RemoveListAsync(List<T> entities, bool withSave = false)
        {
            _db.RemoveRange(entities);
            if (withSave)
                await SaveAsync();
            return entities;
        }

        public async Task<T> RemoveOneAsync(T entity, bool withSave = false)
        {
            _db.Remove(entity);
            if (withSave)
                await SaveAsync();
            return entity;
        }

        public async Task<List<T>> UpdateListAsync(List<T> entities, bool withSave = false)
        {
            _db.UpdateRange(entities);
            if (withSave)
                await SaveAsync();
            return entities;
        }

        public async Task<T> UpdateOneAsync(T entity, bool withSave = false)
        {
            _db.Update(entity);
            if (withSave)
                await SaveAsync();
            return entity;
        }

        #endregion

        #region Save

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        #endregion
    }
}