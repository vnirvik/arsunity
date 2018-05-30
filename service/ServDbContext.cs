using Microsoft.EntityFrameworkCore;
using interfaces;

namespace service
{
    public class ServDbContext : DbContext 
    {
        public ServDbContext(DbContextOptions<ServDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}