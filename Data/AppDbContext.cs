using Microsoft.EntityFrameworkCore;
using user_service.Models;

namespace user_service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}