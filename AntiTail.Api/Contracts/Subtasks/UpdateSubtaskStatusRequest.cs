using System.ComponentModel.DataAnnotations;

namespace AntiTail.Api.Contracts.Subtasks
{
    public record UpdateSubtaskStatusRequest(
        [Required(ErrorMessage = "Status is required.")]
        string Status);
}
