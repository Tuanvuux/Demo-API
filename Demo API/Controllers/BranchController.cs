using BLL.Services;
using BLL.Services.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        public readonly IBranchService _BranchService;
        public BranchController(IBranchService BranchService)
        {
            _BranchService = BranchService;
        }
        [HttpPost]
        public IActionResult Add(Branch branch)
        {
            try
            {
                _BranchService.Add(branch);
                return Ok();
            }
            catch
            {
               return StatusCode(StatusCodes.Status500InternalServerError);
            }
            

        }
    }
    
}
