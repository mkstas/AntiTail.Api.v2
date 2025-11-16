using AntiTail.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AntiTail.Persistence.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .ToTable("exercises")
                .HasKey(e => e.Id);

            builder
                .HasOne(e => e.Subject)
                .WithMany(s => s.Exercises)
                .HasForeignKey(e => e.SubjectId);

            builder
                .HasMany(e => e.Subtasks)
                .WithOne(s => s.Exercise)
                .HasForeignKey(s => s.ExerciseId);

            builder
                .Property(e => e.Id)
                .HasColumnName("id");

            builder
                .Property(e => e.SubjectId)
                .HasColumnName("subject_id");

            builder
                .Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(64)
                .IsRequired();

            builder
                .Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(512)
                .HasDefaultValue("");

            builder
                .Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValue(Status.Pending)
                .HasConversion<string>();
        }
    }
}
