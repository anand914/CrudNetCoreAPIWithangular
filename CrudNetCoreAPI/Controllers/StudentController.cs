using CrudNetCoreAPI.Models;
using CrudNetCoreAPI.Models.ViewModels;
using CrudNetCoreAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CrudNetCoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _srvc;
        public StudentController(IStudent srvc)
        {
            _srvc = srvc;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
               var result = await _srvc.GetAllStudents();
                if (result.StatusCode == 500)
                {
                    return NotFound();
                }
                 return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent( int id)
        {
            try
            {
                var result = await _srvc.GetStudent(id);
                if (result.StatusCode == 500)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult>AddStudent(StudentVM model)
        {
            try
            {
                var result = await _srvc.AddStudent(model);
                if(result.StatusCode == 500)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>EditStudent(int id,[FromBody] StudentVM model)
        {
            try
            {
                var result = await _srvc.Updatestudent(model);
                if (result.StatusCode == 500)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var result = await _srvc.Deletestudent(id);
                if (result.StatusCode == 500)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult>Serach(string name)
        {
            try
            {
                var data = await _srvc.Search(name);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
    }
}
