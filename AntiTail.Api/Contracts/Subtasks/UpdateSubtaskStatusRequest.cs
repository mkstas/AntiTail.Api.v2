using AntiTail.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace AntiTail.Api.Contracts.Subtasks
{
    public record UpdateSubtaskStatusRequest(
        [Required(ErrorMessage = "Status is required.")]
        Status Status);
}
