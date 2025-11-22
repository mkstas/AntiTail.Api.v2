using AntiTail.Api.Contracts.Subtasks;
using AntiTail.Domain.Interfaces.Services;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AntiTail.Api.Controllers
{
    [ApiController]
    [Route("subtasks")]
    public class SubtasksController(
        ISubtaskService subtaskService) : ControllerBase
    {
        private readonly ISubtaskService _subtaskService = subtaskService;

        [HttpPost]
        [Authorize]
        public async Task<IResult> CreateSubtaks([FromBody] CreateSubtaskRequest request)
        {
            try
            {
                var subtask = await _subtaskService.CreateSubtask(request.ExerciseId, request.Title);
                var response = new SubtaskResponse(
                    subtask.Id, subtask.ExerciseId, subtask.Title, subtask.Status.ToString());

                return Results.Created($"/subtasks/{subtask.Id}", response);
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IResult> GetAllSubtasks(long exerciseId)
        {
            try
            {
                var subtasks = await _subtaskService.GetAllSubtasks(exerciseId);

                List<SubtaskResponse> response = [.. subtasks.Select(
                    s => new SubtaskResponse(s.Id, s.ExerciseId, s.Title, s.Status.ToString()))];

                return Results.Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpGet("{id:long}")]
        [Authorize]
        public async Task<IResult> GetSubtaksById(long id)
        {
            try
            {
                var subtask = await _subtaskService.GetSubtaskById(id);
                var response = new SubtaskResponse(
                    subtask.Id, subtask.ExerciseId, subtask.Title, subtask.Status.ToString());

                return Results.Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpPut("{id:long}")]
        [Authorize]
        public async Task<IResult> UpdateSubtask(
            [FromRoute] long id,
            [FromBody] UpdateSubtaskRequest request)
        {
            try
            {
                await _subtaskService.UpdateSubtask(id, request.Title);

                return Results.NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpPatch("{id:long}")]
        [Authorize]
        public async Task<IResult> UpdateSubtaskStatus(
            [FromRoute] long id,
            [FromBody] UpdateSubtaskStatusRequest request)
        {
            try
            {
                await _subtaskService.UpdateSubtaskStatus(id, request.Status);

                return Results.NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(new { message = ex.Message });
            }
            catch (BadRequestException ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpDelete("{id:long}")]
        [Authorize]
        public async Task<IResult> DeleteSubtask([FromRoute] long id)
        {
            try
            {
                await _subtaskService.DeleteSubtask(id);

                return Results.NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }
    }
}
