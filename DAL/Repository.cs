using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase
    {
        private readonly HospitalContext _context;
        private readonly DbSet<T> _data;
        public Repository(HospitalContext context)
        {
            _context = context;
            _data = _context.Set<T>();
        }

        public IResult<T> Get(Expression<Func<T, bool>> predicate)
            => new Result<T>(_data.FirstOrDefault(predicate));

        public IResult<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> map)
            => new Result<TResult>(map(_data.FirstOrDefault(predicate)));

        public Task<IResult<T>> GetAsync(Expression<Func<T, bool>> predicate)
            => Result.From<T>(_data.FirstOrDefaultAsync(predicate));

        public async Task<IResult<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> map)
            => Result.From<TResult>(map(await _data.FirstOrDefaultAsync(predicate)));

        public IResult<List<T>> GetMany(Expression<Func<T, bool>> predicate = null)
        {
            var result = predicate != null
                ? _data.Where(predicate).ToList()
                : _data.ToList();

            return new Result<List<T>>(result);
        }

        public Task<IResult<List<T>>> GetManyAsync(Expression<Func<T, bool>> predicate = null)
        { 
            var resultTask = predicate != null
                ? _data.Where(predicate).ToListAsync()
                : _data.ToListAsync();

            return Result.From(resultTask);
        }

        public IResult<T> Add(T entity)
        {
            var result = _data.Add(entity);

            _context.SaveChanges();

            return Result.From<T>(result.Entity);
        }

        public async Task<IResult<T>> AddAsync(T entity)
        {
            var result = await _data.AddAsync(entity);

            await _context.SaveChangesAsync();

            return Result.From<T>(result.Entity);
        }
    }
}
