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
                _BusinessService.Add(business);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _BusinessService?.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Business business)
        {
            var data = _BusinessService.GetById(id);
            if (data != null)
            {
                business.CustId = data.CustId;
                _BusinessService.Update(business);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
    
}
