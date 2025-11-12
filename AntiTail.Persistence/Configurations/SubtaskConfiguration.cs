using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder)
        {
            builder
                .ToTable("subtasks")
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.Task)
                .WithMany(t => t.Subtasks)
                .HasForeignKey(s => s.TaskId);

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property(s => s.TaskId)
                .HasColumnName("task_id");

            builder
                .Property(s => s.Title)
                .HasColumnName("title")
                .HasMaxLength(64)
                .IsRequired();

            builder
                .Property(s => s.Status)
                .HasColumnName("status")
                .HasDefaultValue(Status.Pending)
                .HasConversion<string>();
        }
    }
}
