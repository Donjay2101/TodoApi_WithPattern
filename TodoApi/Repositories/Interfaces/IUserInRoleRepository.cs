using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;

namespace TodoApi.Repositories.Interfaces
{
    public interface IUserInRoleRepository
    {
        IEnumerable<UserInRole> GetUserInRoles(int userId);
        bool IsUserInRole(int roleId,int userId);
        //bool IsUserInRole(int roleId, int userId);
    }

}
