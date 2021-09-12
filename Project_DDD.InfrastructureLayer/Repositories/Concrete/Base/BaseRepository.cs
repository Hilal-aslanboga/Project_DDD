using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Project_DDD.DomainLayer.Entities.Interface;
using Project_DDD.DomainLayer.Repositories.Interface.Base;
using Project_DDD.InfrastructureLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.InfrastructureLayer.Repositories.Concrete.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> table;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            table = context.Set<T>();
        }

        async Task IRepository<T>.Add(T entity) => await table.AddAsync(entity);

        async Task<bool> IRepository<T>.Any(Expression<Func<T, bool>> expression) => await table.AnyAsync(expression);

        async Task IRepository<T>.Commit() => await _context.SaveChangesAsync();

        void IRepository<T>.Delete(T entity) => table.Remove(entity);

        public ValueTask DisposeAsync(bool v)
        {
            throw new NotImplementedException();
        }

        async Task<T> IRepository<T>.FirstOrDefault(Expression<Func<T, bool>> expression) => await table.Where(expression).FirstOrDefaultAsync();

        async Task<List<T>> IRepository<T>.Get(Expression<Func<T, bool>> expression) => await table.AsNoTracking().Where(expression).ToListAsync();

        async Task<List<T>> IRepository<T>.GetAll() => await table.AsNoTracking().ToListAsync();

        async Task<T> IRepository<T>.GetById(int id) => await table.FindAsync(id);

        async Task<TResult> IRepository<T>.GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = table;
            if (include != null) query = include(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null) return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            else return await query.Select(selector).FirstOrDefaultAsync();
        }

        async Task<List<TResult>> IRepository<T>.GetFilteredList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true, int pageIndex = 1, int pageSize = 3)
        {
            IQueryable<T> query = table;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null) return await orderBy(query).Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            else return await query.Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        void IRepository<T>.Update(T entity) => _context.Entry<T>(entity).State = EntityState.Modified;

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }     
}
