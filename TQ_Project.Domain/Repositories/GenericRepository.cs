using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TQ_Project.Domain.DataAccess;
using TQ_Project.Domain.Entities;
using TQ_Project.Domain.Interfaces;

namespace TQ_Project.Domain.Repositories
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly EfCoreDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(EfCoreDbContext context)
        {
            this._context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> Add(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>>? Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null) return null;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            var entity = await _dbSet.ToListAsync();
            return entity;
        }

        public async Task<T>? GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null) return null;
            return entity;
        }

        public async Task<List<T>>? UpdateById(int id, T requested)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null) return null;

            var entityProperties = typeof(T).GetProperties();

            foreach (var property in entityProperties)
            {
                var requestedValue = property.GetValue(requested);
                if (requestedValue != null)
                {
                    property.SetValue(entity, requestedValue);
                }
            }

            await _context.SaveChangesAsync();

            return await _dbSet.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
