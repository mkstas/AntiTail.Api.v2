using System.ComponentModel.DataAnnotations;

namespace AntiTail.Api.Contracts.Exercises
{
    public record CreateExerciseRequest(
        [Required(ErrorMessage = "Subject id is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Subject id must be at least 1.")]
        long SubjectId,

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(64, ErrorMessage = "Title cannot exceed 64 characters.")]
        string Title,

        [MaxLength(512, ErrorMessage = "Description cannot exceed 512 characters.")]
        string Description);
}
