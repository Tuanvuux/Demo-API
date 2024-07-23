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
        [HttpPut]
        public IActionResult Put( Department department)
        {
            try
            {
                var data = _DepartmentService.GetById(department.DeptId);

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

        [HttpGet]
        public IActionResult GetAll(string name=null)
        {
            if (string.IsNullOrEmpty(name))
            { return Ok(_DepartmentService.GetAll()); }
            else
            {
                return Ok(_DepartmentService.FindByName(name));
            }
            
        }




        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var job = _DepartmentService.GetById(id);

            return StatusCode(200, job);
        }

       
    }
}
