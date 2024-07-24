using BLL.Services;
using BLL.Services.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        public readonly IBranchService _BranchService;
        public BranchController(IBranchService BranchService)
        {
            _BranchService = BranchService;
        }
        [HttpPost]
        public IActionResult Add(Branch branch)
        {
            try
            {
                var bra=_BranchService.Add(branch);
                return Ok(branch);
            }
            catch
            {
               return StatusCode(StatusCodes.Status500InternalServerError);
            }
            

        }

        [HttpPut]
        public IActionResult Put(Branch branch)
        {
            try
            {
                var data = _BranchService.GetById(branch.BranchId);

                branch.BranchId = data.BranchId;
                var Bra = _BranchService.Update(branch);
                return Ok(Bra);
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
                var branhc = _BranchService.Delete(id);
                return Ok(branhc);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            { return Ok(_BranchService.GetAll()); }
            else
            {
                return Ok(_BranchService.FindByName(name));
            }

        }




        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var job = _BranchService.GetById(id);

            return StatusCode(200, job);
        }
    }
    
}
