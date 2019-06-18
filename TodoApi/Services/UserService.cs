using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;
using TodoApi.Services.interfaces;
using TodoApi.UOW;

namespace TodoApi.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<int> Add(User entity)
        {
            await _uow.UserRepository.Add(entity);
            _uow.Save();
            return entity.ID;
        }

        public async Task<bool> Delete(User entity)
        {
            var success = false;
            if (entity != null)
            {
                await _uow.UserRepository.Delete(entity);
                _uow.Save();
                success = true;
            }
            return success;
        }

        public User Get(int id)
        {
            return _uow.UserRepository.GetByID(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _uow.UserRepository.GetAll();
        }

        public IEnumerable<User> GetBy(Func<User, bool> func)
        {
            return _uow.UserRepository.GetBy(func);
        }

        public User GetByUserName(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(User entity)
        {
            var success = false;
            if (entity != null)
            {
                await _uow.UserRepository.Update(entity);
                _uow.Save();
            }
            return success;
        }


   
    }
}
