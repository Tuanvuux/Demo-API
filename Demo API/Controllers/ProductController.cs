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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_ProductService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ProductService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            try
            {
                var Pro=_ProductService.Add(product);
                return Ok(Pro);
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
                var pro=_ProductService.Delete(id);
                return Ok(pro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            try { 
            var data = _ProductService.GetById(id);
                product.ProductCd = data.ProductCd;
                var pro=_ProductService.Update(product);
                return Ok(pro);
            }
            catch (AggregateException ex)
            {
                var errors = ex.InnerExceptions.Select(e => e.Message).ToList();
                return BadRequest(new { Errors = errors });
            }
        }


    }
    
}
