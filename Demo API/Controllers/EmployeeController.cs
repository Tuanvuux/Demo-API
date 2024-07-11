using BLL.Services;
using BLL.Services.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            try
            {
                var emp=_EmployeeService.Add(employee);
                return Ok(emp);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
           
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var account = _EmployeeService.Delete(id);
                return Ok(account);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            try
            {
                var data = _EmployeeService.GetById(id);

                employee.EmpId = data.EmpId;
                var emp = _EmployeeService.Update(employee);
                return Ok(emp);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }

        }

    }
}
