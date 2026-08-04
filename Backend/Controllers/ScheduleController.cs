using Intervoxa_application.Model;
using Intervoxa_application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intervoxa_application.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService service;

        public ScheduleController(IScheduleService service)
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
        public async Task<IActionResult> Add(Scheduledto dto)
        {
            var res = await service.AddSchedule(dto);
            if (res == null)
            {
                return BadRequest("Schedule is not added");
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var res = await service.GetById(id);
            if (res == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Editdetails(int id, Scheduledto dto)
        {
            var res = await service.UpdateSchedule(id,dto);
            if (res == null)
            {
                return BadRequest("Schedule is not updated");
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await service.DeleteSchedule(id);

            if (!res)
            {
                return NotFound();
            }

            return Ok("deleted successfully");
        }


        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, StatusDto dto)
        {
            var res = await service.UpdateStatus(id, dto.Status);

            if (res == null)
            {
                return NotFound("Schedule not found");
            }

            return Ok(res);
        }

        

    }
}
