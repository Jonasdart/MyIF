

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyIF.Dtos.Courses;

public class CourseCreateUpdate
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Workload { get; set; }

    [Required]
    public decimal Price { get; set; }
}
