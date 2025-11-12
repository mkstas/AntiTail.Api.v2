using AntiTail.Domain.Models;
using AntiTail.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence
{
    public class AntiTailDbContext(DbContextOptions<AntiTailDbContext> options)
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new SubtaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
