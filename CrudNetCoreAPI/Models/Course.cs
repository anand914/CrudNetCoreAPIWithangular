using System.Text.Json.Serialization;

namespace CrudNetCoreAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Course_Name { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } 
    }
}
