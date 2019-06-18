using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;

namespace TodoApi.Services.interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Role Get(int id);
        Task<int> Add(Role Entity);
        Task<bool> Update(Role Entity);
        Task<bool> Delete(Role Entity);
    }
}
