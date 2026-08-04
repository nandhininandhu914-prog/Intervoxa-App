using Intervoxa_application.Model;
using Intervoxa_application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Intervoxa_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService service;

        public FeedbackController(IFeedbackService service)
        {
            this.service = service;
        }


        // Get feedback by ScheduleId
        [Authorize(Roles = "Admin,HR,Interviewer")]
        [HttpGet("{scheduleId}")]
        public async Task<IActionResult> GetFeedbackByScheduleId(int scheduleId)
        {
            var result = await service.GetFeedbackByScheduleId(scheduleId);

            if (result == null)
            {
                return NotFound("Feedback not found.");
            }

            return Ok(result);
        }

        // Add feedback
        [HttpPost]
        public async Task<IActionResult> AddFeedback(Feedbackdto dto)
        {
            var result = await service.AddFeedback(dto);

            if (result == null)
            {
                return BadRequest("Feedback already exists or Schedule not found.");
            }

            return Ok(result);
        }

        // Delete feedback
        [HttpDelete("{feedId}")]
        public async Task<IActionResult> DeleteFeedback(int feedId)
        {
            var result = await service.DeleteFeedback(feedId);

            if (!result)
            {
                return NotFound("Feedback not found.");
            }

            return Ok("Feedback deleted successfully.");
        }

        [Authorize(Roles = "Admin,HR")]
        [HttpGet("GetAllFeedback")]
        public async Task<IActionResult> GetallFeedback()
        {
            var result = await service.GetAllFeedback();

            return Ok(result);
        }

        [Authorize(Roles = "Interviewer")]
        [HttpGet("MyFeedback")]
        public async Task<IActionResult> MyFeedback()
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized();
            }

            int userId = int.Parse(userIdClaim);

            var result = await service.GetMyFeedback(userId);

            return Ok(result);
        }
    }
}