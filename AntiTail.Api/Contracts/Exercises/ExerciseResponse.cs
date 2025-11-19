using AntiTail.Domain.Models;

namespace AntiTail.Api.Contracts.Exercises
{
    public record ExerciseResponse(
        long Id,
        long SubjectId,
        string Title,
        string Description,
        string Status);
}
