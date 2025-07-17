using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P5_WebApi.Data;
using P5_WebApi.Models;

namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly SqlDbContext _dbcontext;

        public UserController(SqlDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(User req)
        {
            // register logic

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "All the feilds are required!"
                });
            }

            var user = await _dbcontext.Users.FirstOrDefaultAsync(u=> u.Email == req.Email);

            if (user != null)
            {
                return BadRequest(new
                {
                    message = "User Already Exists"
                });
            }

            var passEncryt = BCrypt.Net.BCrypt.HashPassword(req.Password);

            req.Password = passEncryt;

            await _dbcontext.Users.AddAsync(req);

            await _dbcontext.SaveChangesAsync();



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
