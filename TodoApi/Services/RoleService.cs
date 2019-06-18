using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;
using TodoApi.Services.interfaces;
using TodoApi.UOW;

namespace TodoApi.Services
{
    public class RoleService : IRoleService
    {

        private IUnitOfWork _uow;

        public RoleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Add(Role entity)
        {
            await _uow.RoleRepository.Add(entity);
            _uow.Save();
            return entity.ID;
        }

        public async Task<bool> Delete(Role entity)
        {
            var success = false;
            if (entity != null)
            {
                await _uow.RoleRepository.Delete(entity);
                _uow.Save();
                success = true;
            }
            return success;
        }

        public Role Get(int id)
        {
            var result = _uow.RoleRepository.GetByID(id);
            return result;
        }

        public IEnumerable<Role> GetAll()
        {
            var result = _uow.RoleRepository.GetAll();
            return result;
        }

        public async Task<bool> Update(Role entity)
        {
            var success = false;
            if (entity != null)
            {
                await _uow.RoleRepository.Update(entity);
                _uow.Save();
            }
            return success;
        }
    }
}
