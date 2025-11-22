namespace AntiTail.Api.Contracts.Subtasks
{
    public record SubtaskResponse(
        long Id,
        long ExerciseId,
        string Title,
        string Status);
}
