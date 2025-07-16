using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P5_WebApi.Models;

namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpPost("Register")]
        public IActionResult Register(User req)
        {
            return Ok(new
            {
                message = "Register Succesfull"
            });
        }


        [HttpPost("Login")]
        public IActionResult Login(User req)
        {
            return Ok(new
            {
                message = "Login Succesfull"
            });
        }


        [HttpGet("ForgotPass")]
        public IActionResult ForgotPass(string email)
        {
            return Ok(new
            {
                message = "Email Sent Succesfully"
            });
        }

    }
}
