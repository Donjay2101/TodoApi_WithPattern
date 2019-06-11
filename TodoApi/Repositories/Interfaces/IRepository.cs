using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        IEnumerable<T> GetBy(Func<T,bool> lambda);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
