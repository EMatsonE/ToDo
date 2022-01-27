using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Models
{
    public class TodoContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Task> Task { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Todo;Trusted_Connection=True;");
        }
    }
}
