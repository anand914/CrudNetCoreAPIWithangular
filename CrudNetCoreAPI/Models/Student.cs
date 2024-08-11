using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudNetCoreAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? DOB { get; set; }
        // Foreign key for Course
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course? Course { get; set; }
    }
}
