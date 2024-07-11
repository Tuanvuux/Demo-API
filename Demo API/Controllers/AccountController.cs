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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _AccountService;
        public AccountController(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_AccountService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_AccountService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Account account)
        {
            try
            {
                var Acc=_AccountService.Add(account);
                return Ok(Acc);
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
                var account=_AccountService.Delete(id);
                return Ok(account);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Account account)
        {
            try { 
            var data = _AccountService.GetById(id);
            
                account.Account_Id = data.Account_Id;
                Account acc =_AccountService.Update(account);
                return Ok(acc);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }

        }


    }
    
}
