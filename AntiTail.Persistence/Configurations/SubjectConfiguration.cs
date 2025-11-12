using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .ToTable("subjects")
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.User)
                .WithMany(u => u.Subjects)
                .HasForeignKey(s => s.UserId);

            builder
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Subject)
                .HasForeignKey(t => t.SubjectId);

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property(s => s.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder
                .Property(s => s.Title)
                .HasColumnName("title")
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
