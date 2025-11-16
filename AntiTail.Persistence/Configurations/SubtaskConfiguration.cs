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
                .HasOne(s => s.Exercise)
                .WithMany(e => e.Subtasks)
                .HasForeignKey(s => s.ExerciseId);

            builder
                .Property(s => s.Id)
                .HasColumnName("id");

            builder
                .Property(s => s.ExerciseId)
                .HasColumnName("exercise_id");

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
