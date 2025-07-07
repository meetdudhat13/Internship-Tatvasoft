

using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.Models;

namespace StudentInfo.DataAccess
{
    public class StudentManagmentDbContext : DbContext
    {
        public StudentManagmentDbContext(DbContextOptions<StudentManagmentDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
      
    }
}
