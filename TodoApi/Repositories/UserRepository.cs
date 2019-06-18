using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Repositories.Interfaces;

namespace TodoApi.Repositories
{
    public class UserRepository<T>: BaseRepository<T>, IRepository<T> where T:class
    {
        private AppDBcontext _context = null;
        public UserRepository(AppDBcontext dbcontext) : base(dbcontext)
        {
            _context = dbcontext;
        }
    }
}
