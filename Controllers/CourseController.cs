using Microsoft.AspNetCore.Mvc;
using MyIF.DataModels;
using MyIF.Dtos.Courses;
using MyIF.Models;

namespace MyIF.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    [HttpPost]
    public Course PostCourse([FromBody] Course course, [FromServices] MyIFContext context)
    {
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
    public List<Course> GetCourses([FromServices] MyIFContext context)
    {
        return context.Courses.ToList();
    }

    [HttpGet("{id:int}")]
    public CourseResponse GetCourseFromId([FromRoute] int id, [FromServices] MyIFContext context)
    {
        var course = context.Courses.SingleOrDefault(course => course.Id == id);
        if (course is null)
        {
            Response.StatusCode = 404;
        }
        var response = new CourseResponse();
        response.Id = course.Id;
        response.Description = course.Description;
        response.Name = course.Name;
        response.IsActive = course.IsActive;
        response.Workload = course.Workload;
        response.UpdateDateTime = course.UpdateDateTime;

        return response;
    }

    // [HttpPatch("{id:int}")]
    // public Course UpdateCourseStatus([FromRoute] int id, [FromServices] MyIFContext context)
    // {
    //     context.Courses.Update()
    // }

}
