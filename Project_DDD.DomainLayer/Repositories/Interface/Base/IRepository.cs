using Project_DDD.DomainLayer.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Project_DDD.DomainLayer.Repositories.Interface.Base
{
    public interface IRepository<T> where T:IBaseEntity
    {
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector,
                                                     Expression<Func<T, bool>> expression,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                     bool disableTracking = true,
                                                     int pageIndex = 1, int pageSize = 3);

        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                         Expression<Func<T, bool>> expression,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                         bool disableTracking = true);

        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task Commit();
        ValueTask DisposeAsync();
    }
}
