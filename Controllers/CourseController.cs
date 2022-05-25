using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyIF.DataModels;
using MyIF.Dtos.Courses;
using MyIF.Models;

namespace MyIF.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    [HttpPost]
    public Course PostCourse([FromBody] CourseCreateUpdate courseDto, [FromServices] MyIFContext context)
    {
        var course = courseDto.Adapt<Course>();
        var datetimeNow = DateTime.Now;
        course.CreationDateTime = datetimeNow;
        course.UpdateDateTime = datetimeNow;
        try
        {
            context.Courses.Add(course);
            context.SaveChanges();
            Response.StatusCode = 201;
        }
        catch
        {
            Response.StatusCode = 500;
        }
        return course;
    }

    [HttpGet]
    public List<CourseResponse> GetCourses([FromServices] MyIFContext context)
    {
        return context.Courses.AsNoTracking().ProjectToType<CourseResponse>().ToList();
    }

    [HttpGet("{id:int}")]
    public CourseResponse GetCourseFromId([FromRoute] int id, [FromServices] MyIFContext context)
    {
        var course = context.Courses.AsNoTracking().SingleOrDefault(course => course.Id == id);
        if (course is null)
        {
            Response.StatusCode = 404;
        }
        var response = course.Adapt<CourseResponse>();

        return response;
    }

    [HttpPut("{id:int}")]
    public CourseResponse CourseUpdate([FromRoute] int id, [FromBody] CourseCreateUpdate updatedCourse, [FromServices] MyIFContext context)
    {
        var course = context.Courses.SingleOrDefault(course => course.Id == id);

        if (course is null)
            throw new Exception("Course not found");

        updatedCourse.Adapt(course);
        course.UpdateDateTime = DateTime.Now;

        context.SaveChanges();

        var courseResponse = course.Adapt<CourseResponse>();

        return courseResponse;
    }
}
