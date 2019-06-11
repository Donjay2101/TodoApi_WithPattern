using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoApi.Entities;

namespace TodoApi.Repositories
{
    public class AppDBcontext:DbContext
    {
        public AppDBcontext(DbContextOptions options):base(options){}
        public DbSet<Todo> Todos { get; set; }
    }
}
