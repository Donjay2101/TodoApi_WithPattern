using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;
using TodoApi.Repositories.Interfaces;

namespace TodoApi.Repositories
{
    public class UserInRolesRepository : BaseRepository<UserInRole>,IUserInRoleRepository , IRepository<UserInRole> 
    {
        private AppDBcontext _context = null;
        public UserInRolesRepository(AppDBcontext dbcontext) : base(dbcontext)
        {
            _context = dbcontext;
            _dbSet = dbcontext.Set<UserInRole>();
        }

        public IEnumerable<UserInRole> GetUserInRoles(int userid)
        {
            var result = _dbSet.Where(x => x.UserId == userid).AsEnumerable();
            return result;
        }

        public bool IsUserInRole(int userId, int roleId)
        {
            
            var result = _dbSet.FirstOrDefault(x => x.UserId == userId && x.RoleId == roleId);
            return result == null ? false : true; 
            
        }

        public bool IsUserInRole(int userId, string roleName)
        {
            var result = _dbSet.Where(x => x.UserId == userId && x.RoleName== roleName).AsEnumerable();
            return result == null ? false : true; 
        }
    }
}
