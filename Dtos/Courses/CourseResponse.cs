namespace MyIF.Dtos.Courses;

public class CourseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Workload { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}
