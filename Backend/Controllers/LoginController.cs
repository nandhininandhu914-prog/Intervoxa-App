using Intervoxa_application.Model;
using Intervoxa_application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Intervoxa_application.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginservice;

        public LoginController(ILoginService loginservice)
        {
            this.loginservice = loginservice;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginmodel)
        {
            var res=await loginservice.Login(loginmodel);

            if(res==null)
            {
                return BadRequest("Invalid Credentials");
            }
            
            return Ok(res);
        }
        
    }
}
