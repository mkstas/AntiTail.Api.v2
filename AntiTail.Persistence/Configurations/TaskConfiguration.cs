using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Models.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
        {
            builder
                .ToTable("tasks")
                .HasKey(s => s.Id);

            builder
                .HasOne(t => t.Subject)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.SubjectId);

            builder
                .HasMany(t => t.Subtasks)
                .WithOne(s => s.Task)
                .HasForeignKey(s => s.TaskId);

            builder
                .Property(t => t.Id)
                .HasColumnName("id");

            builder
                .Property(t => t.SubjectId)
                .HasColumnName("subject_id");

            builder
                .Property(t => t.Title)
                .HasColumnName("title")
                .HasMaxLength(64)
                .IsRequired();

            builder
                .Property(t => t.Description)
                .HasColumnName("description")
                .HasMaxLength(512)
                .HasDefaultValue(null);

            builder
                .Property(t => t.Status)
                .HasColumnName("status")
                .HasDefaultValue(Status.Pending)
                .HasConversion<string>();
        }
    }
}
