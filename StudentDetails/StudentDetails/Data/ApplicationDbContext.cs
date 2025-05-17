using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentDetails.Models.Entities;

namespace StudentDetails.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option) { }

        public DbSet<Student> Students {  get; set; }
    }
}
