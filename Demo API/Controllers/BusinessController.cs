using BLL.Services;
using BLL.Services.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _BusinessService;
        public BusinessController(IBusinessService BusinessService)
        {
            _BusinessService = BusinessService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_BusinessService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_BusinessService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Business business)
        {
            try
            {
                var Bu=_BusinessService.Add(business);
                return Ok(Bu);
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
                var business=_BusinessService.Delete(id);
                return Ok(business);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Business business)
        {
            try
            {
                var data = _BusinessService.GetById(id);       
                business.CustId = data.CustId;
                var Acc=_BusinessService.Update(business);
                return Ok(Acc);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }


    }
    
}
