using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P0_ClassLibrary.Interfaces;
using P5_WebApi.Data;
using P5_WebApi.Models;

namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly SqlDbContext dbcontext;
        // private readonly ICloudinaryService cloudinaryService;
        private readonly ITokenService tokenService;

        public UserController(SqlDbContext dbContext, ITokenService tokenService)
        {
            this.dbcontext = dbContext;
            // this.cloudinaryService = cloudinaryService;
            this.tokenService = tokenService;
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

            var user = await dbcontext.Users.FirstOrDefaultAsync(u=> u.Email == req.Email);

            if (user != null)
            {
                return BadRequest(new
                {
                    message = "User Already Exists"
                });
            }


            var passEncryt = BCrypt.Net.BCrypt.HashPassword(req.Password);

            req.Password = passEncryt;

            await dbcontext.Users.AddAsync(req);

            await dbcontext.SaveChangesAsync();

           var token =  tokenService.CreateToken(req.UserId, req.Email, req.Username ?? "Guest User", 24);


            // token ko  cookies may send kerna hai  




            // message and token ko json object may send kerdiya philhaal
            return Ok(new
            {
                message = "Register Succesfull",
                payload = req
                // authToken = token
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
