using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TodoApi.Entities;
using TodoApi.Repositories.Interfaces;
using TodoApi.Services.interfaces;
using TodoApi.UOW;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        
        private IUnitOfWork _uow;

        public TodoService()
        {
        }
        public TodoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Add(Todo entity)
        {
            using (var scope = new TransactionScope())
            {
                
                await _uow.TodoRepository.Add(entity);
                _uow.Save();
                scope.Complete();
                return entity.ID;
            }
            

        }

        public async Task<bool> Delete(Todo entity)
        {
            var success = false;
            if (entity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var todo = _uow.TodoRepository.GetByID(entity.ID);
                    if (todo != null)
                    {
                        await _uow.TodoRepository.Delete(todo);
                        _uow.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
            
        }

        public Todo Get(int id)
        {
            return _uow.TodoRepository.GetByID(id);
        }

        public IEnumerable<Todo> GetAll()
        {
            return _uow.TodoRepository.GetAll();
        }

        public async Task<bool> Update(Todo entity)
        {
            var success = false;
            if (entity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var todo = _uow.TodoRepository.GetByID(entity.ID);
                    if (todo != null)
                    {
                        todo.Task = entity.Task;
                        await _uow.TodoRepository.Delete(todo);
                        _uow.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
