using System.ComponentModel.DataAnnotations;

namespace AntiTail.Api.Contracts.Subjects
{
    public record UpdateSubjectRequest(
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(64, ErrorMessage = "Title cannot exceed 64 characters.")]
        string Title);
}
