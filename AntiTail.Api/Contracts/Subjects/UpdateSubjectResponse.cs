namespace AntiTail.Api.Contracts.Subjects
{
    public record UpdateSubjectResponse(
        long Id,
        long UserId,
        string Title);
}
