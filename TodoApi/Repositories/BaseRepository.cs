using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Repositories.Interfaces;
using System.Linq;

namespace TodoApi.Repositories
{
    public class BaseRepository<T> where T:class
    {
        AppDBcontext _dbcontext;
        internal DbSet<T> _dbSet;

        public BaseRepository(AppDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = _dbcontext.Set<T>();
        }

        public Task Add(T entity)
        {
            return Task.Run(() =>
            {
                _dbSet.Add(entity);
            });
        }

        public Task Delete(T entity)
        {
            return Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
            //return _dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetBy(Func<T,bool> lambda)
        {
            return _dbSet.Where(lambda);
        }

        public T GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public Task Update(T entity)
        {
            return Task.Run(() =>
            {
                _dbSet.Attach(entity);
                _dbcontext.Entry(entity).State = EntityState.Modified;
            });
        }
    }
}
