using CrudNetCoreAPI.Data;
using CrudNetCoreAPI.Models;
using CrudNetCoreAPI.Models.ViewModels;
using CrudNetCoreAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrudNetCoreAPI.Services
{
    public class StudentServices : IStudent
    {
        private readonly StudentContext _context;
        public StudentServices(StudentContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> AddStudent(StudentVM model)
        {
            try
            {
                if (model.StudentId == 0)
                {
                    var course = await _context.Courses.FirstOrDefaultAsync(c => c.Course_Name == model.CourseName);
                    if (course == null)
                    {
                        course = new Course
                        {
                            Course_Name = model.CourseName,
                        };
                        _context.Courses.Add(course);
                        await _context.SaveChangesAsync();
                    }
                    Student obj = new Student()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        DOB = model.DOB,
                        CourseId = course.Id
                    };
                    _context.Students.Add(obj);
                    await _context.SaveChangesAsync();
                    return new ApiResponse()
                    {
                        Status = true,
                        StatusCode = 200,
                        Data = "Student Added Successfull !!",
                        Errors = null
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public async Task<ApiResponse> Deletestudent(int id)
        {
            try
            {
                var result = await _context.Students.Where(s => s.StudentId == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Students.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return new ApiResponse()
                {
                    Status = true,
                    StatusCode = 200,
                    Data = result,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ApiResponse> GetAllStudents()
        {
            try
            {
                var data = await _context.Students
             .Include(s => s.Course) // Assuming Student has a navigation property called Course
             .Select(s => new
             {
                 s.StudentId,
                 s.FirstName,
                 s.LastName,
                 s.Address,
                 s.DOB,
                 CourseName = s.Course.Course_Name // Assuming Course has a property called CourseName
             })
             .ToListAsync();
                if (data.Count > 0)
                {
                    return new ApiResponse()
                    {
                        Status = true,
                        StatusCode = 200,
                        Data = data,
                        Errors = null
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ApiResponse> GetCourse()
        {
            try
            {
                var result = await _context.Courses.ToListAsync();
                return new ApiResponse()
                {
                    StatusCode = 200,
                    Status = true,
                    Data = result,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ApiResponse> GetStudent(int id)
        {
            try
            {
                var data = await _context.Students.Where(x => x.StudentId == id)
                                                    .Where(x => x.StudentId == id)
            .Select(student => new
            {
                student.StudentId,
                student.FirstName,
                student.LastName,
                student.Address,
                student.DOB,
                student.CourseId,
                CourseName = student.Course.Course_Name // Assuming there is a navigation property to Course
            })
            .FirstOrDefaultAsync();
                if (data != null)
                {
                    return new ApiResponse()
                    {
                        Status = true,
                        StatusCode = 200,
                        Data = data,
                        Errors = null
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ApiResponse> Search(string name)
        {
            try
            {
                var result = await _context.Students
                    .Include(s => s.Course) // Assuming you have a Course navigation property in your Student entity
                    .FirstOrDefaultAsync(x => x.FirstName.ToLower() == name.ToLower());

                if (result != null)
                {
                    var studentVM = new StudentVM
                    {
                        StudentId = result.StudentId,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        Address = result.Address,
                        DOB = result.DOB, // Format DOB as needed
                        CourseId = result.CourseId,
                        CourseName = result.Course?.Course_Name // Assuming Course has a CourseName property
                    };

                    return new ApiResponse
                    {
                        StatusCode = 200,
                        Status = true,
                        Data = studentVM,
                        Errors = null
                    };
                }

                return new ApiResponse
                {
                    StatusCode = 404,
                    Status = false,
                    Data = null,
                    Errors = new List<string> { "Student not found." }
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ApiResponse> Updatestudent(StudentVM model)
        {
            try
            {
                var result = await _context.Students.Where(x => x.StudentId == model.StudentId).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.StudentId = model.StudentId;
                    result.FirstName = model.FirstName;
                    result.LastName = model.LastName;
                    result.Address = model.Address;
                    result.DOB = model.DOB;
                    result.CourseId = model.CourseId;
                    var course = await _context.Courses.Where(c => c.Id == model.CourseId).FirstOrDefaultAsync();
                    if (course != null)
                    {
                        course.Course_Name = model.CourseName;
                    }
                    //var course = await _context.Courses.FirstOrDefaultAsync(c => c.Course_Name == model.CourseName);
                    //if (course != null)
                    //{
                    //    course.Id = model.CourseId;
                    //    course.Course_Name = model.CourseName;
                    //}
                    _context.Students.Update(result);
                    await _context.SaveChangesAsync();
                }
                return new ApiResponse()
                {
                    Status = true,
                    StatusCode = 200,
                    Data = result,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
