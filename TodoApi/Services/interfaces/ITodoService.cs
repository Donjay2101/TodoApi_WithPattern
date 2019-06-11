using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;

namespace TodoApi.Services.interfaces
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll();
        Todo Get(int id);
        Task<int> Add(Todo Entity);
        Task<bool> Update(Todo Entity);
        Task<bool> Delete(Todo Entity);
    }
}
