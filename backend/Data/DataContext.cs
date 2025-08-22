using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
