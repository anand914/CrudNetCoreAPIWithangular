using Microsoft.AspNetCore.Components.Web;

namespace CrudNetCoreAPI.Models.ViewModels
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public object? Data { get; set; }
        public List<string>?Errors { get; set; }
    }
}
