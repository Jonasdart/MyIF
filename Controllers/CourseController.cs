using Microsoft.AspNetCore.Mvc;
using MyIF.DataModels;
using MyIF.Models;

namespace MyIF.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : Controller
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
    public Course GetCourseFromId([FromRoute] int id, [FromServices] MyIFContext context)
    {
        var course = context.Courses.SingleOrDefault(course => course.Id == id);
        if (course is null)
        {
            Response.StatusCode = 404;
        }
        return course;
    }

    // [HttpPatch("{id:int}")]
    // public Course UpdateCourseStatus([FromRoute] int id, [FromServices] MyIFContext context)
    // {
    //     context.Courses.Update()
    // }

}
