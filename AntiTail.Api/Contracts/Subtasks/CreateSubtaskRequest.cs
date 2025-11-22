using System.ComponentModel.DataAnnotations;

namespace AntiTail.Api.Contracts.Subtasks
{
    public record CreateSubtaskRequest(
        [Required(ErrorMessage = "Exercise id is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Exercise id must be at least 1.")]
        long ExerciseId,

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(64, ErrorMessage = "Title cannot exceed 64 characters.")]
        string Title);
}
