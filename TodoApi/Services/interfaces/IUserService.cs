using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;

namespace TodoApi.Services.interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User GetByUserName(string name);
        IEnumerable<User> GetBy(Func<User,bool> func);
        Task<int> Add(User Entity);
        Task<bool> Update(User Entity);
        Task<bool> Delete(User Entity);
    }
}
