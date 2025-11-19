using AntiTail.Api.Contracts.Exercises;
using AntiTail.Domain.Interfaces.Exercises;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AntiTail.Api.Controllers
{
    [ApiController]
    [Route("exercises")]
    public class ExercisesController(
        IExerciseService exerciseService) : ControllerBase
    {
        private readonly IExerciseService _exerciseService = exerciseService;

        [HttpPost]
        [Authorize]
        public async Task<IResult> CreateExercise([FromBody] CreateExerciseRequest request)
        {
            try
            {
                var exercise = await _exerciseService.CreateExercise(
                    request.SubjectId, request.Title, request.Description);
                var response = new ExerciseResponse(
                    exercise.Id, exercise.SubjectId, exercise.Title, exercise.Description, exercise.Status.ToString());

                return Results.Created($"/exercises/{exercise.Id}", response);
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
        public async Task<IResult> GetAllExercises(long subjectId)
        {
            try
            {
                var exercises = await _exerciseService.GetAllExercises(subjectId);

                List<ExerciseResponse> response = [.. exercises.Select(
                    e => new ExerciseResponse(e.Id, e.SubjectId, e.Title, e.Description, e.Status.ToString()))];

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
        public async Task<IResult> GetExercisesById([FromRoute] long id)
        {
            try
            {
                var exercise = await _exerciseService.GetExerciseById(id);
                var response = new ExerciseResponse(
                    exercise.Id, exercise.SubjectId, exercise.Title, exercise.Description, exercise.Status.ToString());

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
        public async Task<IResult> UpdateExercise(
            [FromRoute] long id,
            [FromBody] UpdateExerciseRequest request)
        {
            try
            {
                await _exerciseService.UpdateExercise(id, request.Title, request.Description);

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
        public async Task<IResult> UpdateExerciseStatus(
            [FromRoute] long id,
            [FromBody] UpdateExerciseStatusRequest request)
        {
            try
            {
                await _exerciseService.UpdateExerciseStatus(id, request.Status);

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

        [HttpDelete("{id:long}")]
        [Authorize]
        public async Task<IResult> DeleteExercise([FromRoute] long id)
        {
            try
            {
                await _exerciseService.DeleteExercise(id);

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
