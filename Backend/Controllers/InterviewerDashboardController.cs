using Intervoxa_application.Data;
using Intervoxa_application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Intervoxa_application.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class InterviewerDashboardController : ControllerBase
    {
        private readonly IInterviewerdashboardService service;
        public InterviewerDashboardController(IInterviewerdashboardService service)
        {
            this.service= service;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Getdashboard(int Id)
        {
            var res=await service.Getdashboard(Id);
            return Ok(res);
        }

        [HttpGet("Myinterviews/{interviewid}")]
        public async Task<IActionResult> Getmyinterview(int interviewid)
        {
            var res=await service.GetInterviewbyId(interviewid);
            return Ok(res);
        }

    }
}
