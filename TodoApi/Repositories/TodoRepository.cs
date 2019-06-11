using TodoApi.Repositories.Interfaces;

namespace TodoApi.Repositories
{
    public class TodoRepository<T> : BaseRepository<T>, IRepository<T> where T:class
    {
        private AppDBcontext _context = null;
        public TodoRepository(AppDBcontext dbcontext) : base(dbcontext)
        {
            _context = dbcontext;
        }
    }
}
