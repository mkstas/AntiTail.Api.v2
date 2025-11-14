namespace AntiTail.Api.Contracts.Subjects
{
    public record CreateSubjectResponse(
        long Id,
        long UserId,
        string Title);
}
