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
            if (customerDTO.CustTypeCd == "B" || customerDTO.CustTypeCd.Equals("I"))
            {
                try
                {
                    _CustomerService.AddDTO(customerDTO);
                    return Ok("Customer registered successfully.");
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
            else
            {
                return BadRequest("CUST_TYPE_CD Invalid");
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _CustomerService?.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            var data = _CustomerService.GetById(id);
            if (data != null)
            {
                customer.CustId = data.CustId;
                _CustomerService.Update(customer);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
    
}
