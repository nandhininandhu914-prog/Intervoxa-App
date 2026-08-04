using Intervoxa_application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Intervoxa_application.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService service;

        public DashboardController(IDashboardService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Getalldata()
        {
            var res=await service.GetallCount();
            if(res==null)
            {
                return BadRequest("Data not found");
            }

            return Ok(res);
        }
    }
}
