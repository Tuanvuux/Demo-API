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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _ProductTypeService;
        public ProductTypeController(IProductTypeService ProductTypeService)
        {
            _ProductTypeService = ProductTypeService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_ProductTypeService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ProductTypeService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(ProductType productType)
        {
            try
            {
                _ProductTypeService.Add(productType);
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
                _ProductTypeService?.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductType productType)
        {
            var data = _ProductTypeService.GetById(id);
            if (data != null)
            {
                productType.ProductTypeCd = data.ProductTypeCd;
                _ProductTypeService.Update(productType);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
    
}
