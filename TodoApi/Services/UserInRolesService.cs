using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;
using TodoApi.Services.interfaces;
using TodoApi.UOW;

namespace TodoApi.Services
{
    public class UserInRolesService : IUserInRoleService
    {
        private IUnitOfWork _uow;

        public UserInRolesService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Add(UserInRole entity)
        {
            await _uow.UserInRoleRepository.Add(entity);
            _uow.Save();
            return entity.ID;
        }

        public async Task<bool> Delete(UserInRole entity)
        {
            var success = false;
            if (entity != null)
            {
                    await _uow.UserInRoleRepository.Delete(entity);
                    _uow.Save();
                success = true;
            }
            return success;
        }

        public UserInRole Get(int id)
        {
            var result = _uow.UserInRoleRepository.GetByID(id);
            return result;
        }

        public IEnumerable<UserInRole> GetAll()
        {
            var result = _uow.UserInRoleRepository.GetAll();
            return result;
        }

        public IEnumerable<UserInRole> GetUserInRoles(int userid)
        {
            var result = _uow.UserInRoleRepository.GetBy(x => x.UserId == userid);
            return result;
        }

        public Task<bool> IsUserInRole(int userId, int roleId)
        {
            return Task.Run(() =>
            {
                var result = _uow.UserInRoleRepository.GetBy(x => x.UserId == userId && x.RoleId == roleId).FirstOrDefault();
                return result == null ? false : true;
            });
        }

        public Task<bool> IsUserInRole(int userId, string roleName)
        {
            return Task.Run(() =>
            {
                var result = _uow.UserInRoleRepository.GetBy(x => x.UserId == userId && x.RoleName == roleName).FirstOrDefault();
                return result == null ? false : true;
            });
        }

        public async Task<bool> Update(UserInRole entity)
        {
            var success = false;
            if (entity != null)
            {
                await _uow.UserInRoleRepository.Update(entity);
                _uow.Save();
            }
            return success;
        }

        
    }
}
