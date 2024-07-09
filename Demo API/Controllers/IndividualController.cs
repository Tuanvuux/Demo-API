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
    public class IndividualController : ControllerBase
    {
        private readonly IIndividualService _IndividualService;
        public IndividualController(IIndividualService IndividualService)
        {
            _IndividualService = IndividualService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_IndividualService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_IndividualService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Individual individual)
        {
            try
            {
                _IndividualService.Add(individual);
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
                _IndividualService?.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Individual individual)
        {
            var data = _IndividualService.GetById(id);
            if (data != null)
            {
                individual.Cust_Id = data.Cust_Id;
                _IndividualService.Update(individual);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
    
}
