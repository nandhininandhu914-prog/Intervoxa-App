using Intervoxa_application.Model;
using Intervoxa_application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Intervoxa_application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var res = await candidateService.Getcandidate();

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }

        [HttpPost]
        public async Task<IActionResult> Addcandidate(CandidateDto candidate)
        {
            var res=await candidateService.Addcandidate(candidate);
            if(res == null)
            {
                return BadRequest("Candidate is not added");
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var res=await candidateService.Getbyid(id);
            if(res==null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Editdetails(int id,CandidateDto candidate)
        {
            var res = await candidateService.Editcandidate(id,candidate);
            if (res == null)
            {
                return BadRequest("Candidate is not added");
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteCandidate(int id)
        {
            var res = await candidateService.Deletecandidate(id);

            if (!res)
            {
                return NotFound();
            }

            return Ok("Candidate deleted successfully");
        }
    }
}
