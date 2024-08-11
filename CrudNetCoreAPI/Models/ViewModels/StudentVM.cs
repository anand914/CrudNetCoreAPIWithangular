namespace CrudNetCoreAPI.Models.ViewModels
{
    public class StudentVM
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? DOB { get; set; }
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
    }
}

