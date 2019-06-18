using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;

namespace TodoApi.Services.interfaces
{
    public interface IUserInRoleService
    {
        IEnumerable<UserInRole> GetAll();
        UserInRole Get(int id);

        IEnumerable<UserInRole> GetUserInRoles(int userid);
        Task<bool> IsUserInRole(int userId, int roleId);
        Task<bool> IsUserInRole(int userId, string roleName);

        Task<int> Add(UserInRole Entity);
        Task<bool> Update(UserInRole Entity);
        Task<bool> Delete(UserInRole Entity);
    }
}
