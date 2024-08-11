using CrudNetCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNetCoreAPI.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options): base(options)
        {
                
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course>Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);
        }
    }
}
