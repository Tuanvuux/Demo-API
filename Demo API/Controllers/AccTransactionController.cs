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
                AccTransaction Acctran=_AccTransactionService.Add(accTransaction);
                return Ok(Acctran);
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
                var AccTran=_AccTransactionService?.Delete(id);
                return Ok(AccTran);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AccTransaction accTransaction)
        {
            try
            {
                var data = _AccTransactionService.GetById(id);
            
                accTransaction.Txn_Id = data.Txn_Id;
                var AccTran= _AccTransactionService.Update(accTransaction);
                return Ok(AccTran);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }


    }
    
}
