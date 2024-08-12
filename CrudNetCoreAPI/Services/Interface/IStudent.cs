using CrudNetCoreAPI.Models;
using CrudNetCoreAPI.Models.ViewModels;

namespace CrudNetCoreAPI.Services.Interface
{
    public interface IStudent
    {
        Task<ApiResponse> GetAllStudents();
        Task<ApiResponse> GetStudent(int id);
        Task<ApiResponse> AddStudent (StudentVM model);
        Task<ApiResponse> Updatestudent(StudentVM model);
        Task<ApiResponse> Deletestudent(int id);
        Task<ApiResponse>Search(string name);
        Task<ApiResponse> GetCourse();

    }
}
