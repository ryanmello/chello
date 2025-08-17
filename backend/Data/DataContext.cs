using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
            
        }

        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<ChelloMessage> ChelloMessages { get; set; }
    }
}
