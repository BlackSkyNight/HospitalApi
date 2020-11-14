using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> : IDisposable where T : class, IEntityBase
    {
        IResult<T> Get(Expression<Func<T, bool>> predicate);
        IResult<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> map);
        Task<IResult<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IResult<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> map);
        IResult<List<T>> GetMany(Expression<Func<T, bool>> predicate = null);
        Task<IResult<List<T>>> GetManyAsync(Expression<Func<T, bool>> predicate = null);
        IResult<T> Add(T entity);
        Task<IResult<T>> AddAsync(T entity);
    }
}