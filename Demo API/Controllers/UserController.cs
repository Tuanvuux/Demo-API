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
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_UserService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                return Ok(_UserService.FindByEmail(email));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("login/")]
        public IActionResult Login(User user)
        {
            try
            {
                var ind = _UserService.CheckUser(user);
                return Ok(ind);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }

        [HttpPost("register/")]
        public IActionResult Add(User user)
        {
            try
            {
                var ind = _UserService.Add(user);
                return Ok(ind);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }

       

        
        


    }

}
