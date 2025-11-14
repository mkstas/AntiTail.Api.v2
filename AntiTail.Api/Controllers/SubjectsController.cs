using AntiTail.Api.Contracts.Subjects;
using AntiTail.Domain.Interfaces.Subjects;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AntiTail.Api.Controllers
{
    [ApiController]
    [Route("subjects")]
    public class SubjectsController(
        ISubjectService subjectService)
    {
        private readonly ISubjectService _subjectService = subjectService;

        [HttpGet]
        public async Task<IResult> GetAllSubjects()
        {
            try
            {
                var subjects = await _subjectService.GetAllSubjects(1);

                return Results.Ok(subjects);
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

        [HttpGet("{id}")]
        public async Task<IResult> GetSubjectById([FromRoute] long id)
        {
            try
            {
                var subject = await _subjectService.GetSubjectById(id);

                return Results.Ok(subject);
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
        public async Task<IResult> CreateSubject([FromBody] CreateSubjectRequest request)
        {
            try
            {
                var subject = await _subjectService.CreateSubject(1, request.Title);
                var response = new CreateSubjectResponse(subject.Id, 1, subject.Title);

                return Results.Created($"/subjects/{subject.Id}", response);
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

        [HttpPut("{id}")]
        public async Task<IResult> UpdateSubject(
            [FromRoute] long id,
            [FromBody] UpdateSubjectRequest request)
        {
            try
            {
                var subject = await _subjectService.UpdateSubject(1, id, request.Title);
                var response = new UpdateSubjectResponse(subject.Id, 1, subject.Title);

                return Results.Ok(response);
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

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteSubject(
            [FromRoute] long id)
        {
            try
            {
                await _subjectService.DeleteSubject(id);

                return Results.NoContent();
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
