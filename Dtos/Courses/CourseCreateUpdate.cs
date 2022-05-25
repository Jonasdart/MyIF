

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyIF.Dtos.Courses;

public class CourseCreateUpdate
{
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }

    [Required]
    public int Workload { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Price { get; set; }
}
