using AntiTail.Api.Contracts.Subjects;
using AntiTail.Api.Extensions;
using AntiTail.Domain.Interfaces.Services;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AntiTail.Api.Controllers
{
    [ApiController]
    [Route("subjects")]
    public class SubjectsController(
        ISubjectService subjectService) : ControllerBase
    {
        private readonly ISubjectService _subjectService = subjectService;

        [HttpGet]
        [Authorize]
        public async Task<IResult> GetAllSubjects()
        {
            try
            {
                var subjects = await _subjectService.GetAllSubjects(User.GetUserId());

                List<SubjectResponse> response = [.. subjects.Select(
                    s => new SubjectResponse(s.Id, s.UserId, s.Title))];

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
        public async Task<IResult> GetSubjectById([FromRoute] long id)
        {
            try
            {
                var subject = await _subjectService.GetSubjectById(id);

                var response = new SubjectResponse(subject.Id, subject.UserId, subject.Title);

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

        [HttpPost]
        [Authorize]
        public async Task<IResult> CreateSubject([FromBody] CreateSubjectRequest request)
        {
            try
            {
                var subject = await _subjectService.CreateSubject(User.GetUserId(), request.Title);

                var response = new SubjectResponse(subject.Id, User.GetUserId(), subject.Title);

                return Results.Created($"/subjects/{subject.Id}", response);
            }
            catch (UnauthorizedAccessException)
            {
                return Results.Unauthorized();
            }
            catch (ConflictException ex)
            {
                return Results.Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpPut("{id:long}")]
        [Authorize]
        public async Task<IResult> UpdateSubject(
            [FromRoute] long id,
            [FromBody] UpdateSubjectRequest request)
        {
            try
            {
                var subject = await _subjectService.UpdateSubject(id, User.GetUserId(), request.Title);

                var response = new SubjectResponse(subject.Id, User.GetUserId(), subject.Title);

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
            catch (ConflictException ex)
            {
                return Results.Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpDelete("{id:long}")]
        [Authorize]
        public async Task<IResult> DeleteSubject(
            [FromRoute] long id)
        {
            try
            {
                await _subjectService.DeleteSubject(id);

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
