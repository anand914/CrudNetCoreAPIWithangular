using CrudNetCoreAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CrudNetCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IStudent _studentSrvc;
        public CourseController(IStudent service) 
        {
           _studentSrvc = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourse()
        {
            try
            {
                var course = await _studentSrvc.GetCourse();
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
