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
    public class AccTransactionController : ControllerBase
    {
        private readonly IAccTransactionService _AccTransactionService;
        public AccTransactionController(IAccTransactionService AccTransactionService)
        {
            _AccTransactionService = AccTransactionService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_AccTransactionService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_AccTransactionService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(AccTransaction accTransaction)
        {
            try
            {
                _AccTransactionService.Add(accTransaction);
                return Ok(new { Message = "AccTransaction added successfully" });
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred while adding the AccTransaction." });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _AccTransactionService?.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AccTransaction accTransaction)
        {
            var data = _AccTransactionService.GetById(id);
            if (data != null)
            {
                accTransaction.Txn_Id = data.Txn_Id;
                _AccTransactionService.Update(accTransaction);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
    
}
