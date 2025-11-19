using AntiTail.Domain.Models;

namespace AntiTail.Api.Contracts.Exercises
{
    public record UpdateExerciseStatusRequest(
        Status Status);
}
