using System.ComponentModel.DataAnnotations;

namespace AntiTail.Api.Contracts.Exercises
{
    public record UpdateExerciseStatusRequest(
        [Required(ErrorMessage = "Status is required.")]
        string Status);
}
