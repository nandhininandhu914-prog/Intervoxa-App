using Intervoxa_application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Intervoxa_application.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HRDashboardController : ControllerBase
    {
        private readonly IHRDashboard hr;

        public HRDashboardController(IHRDashboard hr)
        {
            this.hr = hr;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var res= await hr.Get();
            return Ok(res);
        }
    }
}
