using BLL.Services;
using BLL.Services.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController: ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            try
            {
                var Dep=_DepartmentService.Add(department);
                return Ok(Dep);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Department department)
        {
            try
            {
                var data = _DepartmentService.GetById(id);

                department.DeptId = data.DeptId;
                Department Dep = _DepartmentService.Update(department);
                return Ok(Dep);
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
                var department = _DepartmentService.Delete(id);
                return Ok(department);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
