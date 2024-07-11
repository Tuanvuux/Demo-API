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
                var ind=_IndividualService.Add(individual);
                return Ok(ind);
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
                var ind=_IndividualService.Delete(id);
                return Ok(ind);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Individual individual)
        {
            try
            { 
            var data = _IndividualService.GetById(id);
            
                individual.Cust_Id = data.Cust_Id;
                var Ind=_IndividualService.Update(individual);
                return Ok(Ind);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }


    }
    
}
