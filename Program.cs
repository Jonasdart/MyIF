using Microsoft.EntityFrameworkCore;
using MyIF.DataModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add configurations to contextDb
builder.Services.AddDbContext<MyIFContext>(
    // Using mysql database
    options => options.UseMySql(
        // Getting mysql connection info
        builder.Configuration.GetConnectionString("MyIFDatabase"),
        // Getting database version, automatically
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MyIFDatabase"))
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
