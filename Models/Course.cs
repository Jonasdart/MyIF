namespace MyIF.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Workload { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime AtualizationDateTime { get; set; }
    public decimal Price { get; set; }
}
