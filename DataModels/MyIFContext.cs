using Microsoft.EntityFrameworkCore;
using MyIF.Models;

namespace MyIF.DataModels;

public class MyIFContext : DbContext
{
    // To configure application with dotnet core webapi defaults
    public MyIFContext(DbContextOptions<MyIFContext> options) : base(options)
    {

    }

    // To create properties for each table on database
    public DbSet<Course> Courses { get; set; }
}
