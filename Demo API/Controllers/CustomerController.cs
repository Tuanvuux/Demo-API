using BLL.Services;
using BLL.Services.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DAL.DTO;
namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }
        [HttpGet("{name}")]
        public IActionResult GetName(string name)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_CustomerService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_CustomerService.GetAll());
        }

        [HttpPost]
        public IActionResult AddDTO(CustomerDTO customerDTO)
        {
        try
        {
            var Cus=_CustomerService.AddDTO(customerDTO);
            return Ok(Cus);
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
                var customer=_CustomerService.Delete(id);
                return Ok(customer);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            try
            { 
            var data = _CustomerService.GetById(id);
            
                customer.CustId = data.CustId;
                var Cus=_CustomerService.Update(customer);
                return Ok(Cus);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }


    }
    
}
