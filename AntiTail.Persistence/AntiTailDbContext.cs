using AntiTail.Domain.Models;
using AntiTail.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence
{
    public class AntiTailDbContext(DbContextOptions<AntiTailDbContext> options)
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
