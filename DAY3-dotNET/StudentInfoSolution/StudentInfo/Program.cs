using StudentInfo.DataAccess;
using StudentInfo.DataAccess.Repositories;
using StudentInfo.Services.Services;
using Microsoft.EntityFrameworkCore; // Add this using directive to resolve 'UseNpgsql'  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentManagmentDbContext>(db => db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<StudentRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
