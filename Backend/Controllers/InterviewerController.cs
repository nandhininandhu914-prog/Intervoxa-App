using Intervoxa_application.Model;
using Intervoxa_application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Intervoxa_application.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class InterviewerController : ControllerBase
    {
        private readonly IinterviewerService service;

        public InterviewerController(IinterviewerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var res = await service.Getall();

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }

        [HttpPost]
        public async Task<IActionResult> Addcandidate(InterviewerDto dto)
        {
            var res = await service.Add(dto);
            if (res == null)
            {
                return BadRequest("Interviewer is not added");
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var res = await service.GetByID(id); 
            if (res == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Editdetails(int id, InterviewerDto dto)
        {
            var res = await service.Update(id, dto);
            if (res == null)
            {
                return BadRequest("Interviewer is not added");
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var res = await service.Delete(id);

            if (!res)
            {
                return NotFound();
            }

            return Ok("Intervviewer deleted successfully");
        }
    }
}
