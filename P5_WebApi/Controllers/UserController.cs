
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P0_ClassLibrary.Interfaces;
using P5_WebApi.Data;
using P5_WebApi.Models.DomainModels;


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

            if (string.IsNullOrEmpty(req.Username) || string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Password))
            {
                return BadRequest(new
                {
                    message = "All the feilds are required!"
                });
            }

            var user = await dbcontext.Users.FirstOrDefaultAsync(u => u.Email == req.Email);

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

            var token = tokenService.CreateToken(req.UserId, req.Email, req.Username ?? "Guest User", 60*24*7);

            HttpContext.Response.Cookies.Append("Authorization_Token_React", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(24*7)
            });


            return Ok(new
            {
                message = "Register Succesfull",
                payload = req,
                authToken = token
            });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(User req)
        {
            try
            {
                if (string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Password))
                {
                    return BadRequest(new
                    {
                        message = "All the feilds are required!"
                    });
                }

                var existingUser = await dbcontext.Users.FirstOrDefaultAsync(u => u.Email == req.Email);

                if (existingUser == null)
                {
                    return StatusCode(404, new { message = "User not Found!" });
                }
                var checkPass = BCrypt.Net.BCrypt.Verify(req.Password, existingUser.Password);

                if (checkPass)
                {
                    var token = tokenService.CreateToken(existingUser.UserId, req.Email, existingUser.Username ?? "John Doe", 60 * 24 *7);

                    HttpContext.Response.Cookies.Append("Authorization_Token_React", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = false,
                        SameSite = SameSiteMode.None,
                        Expires = DateTime.UtcNow.AddHours(24 *7)
                    });


                    return Ok(new
                    {
                        message = "Login SuccesFull !",
                        payload = existingUser,
                        authToken = token,
                    });

                }

                else
                {
                    return StatusCode(400, new { message = "Password inccorrect" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = "Internal server Error!" });
            }

        }

        [HttpGet("Verify")]
        public IActionResult Verify(string token)
        {
            if (token == null)
            {
                return StatusCode(401, new { message = "Unauthorized to access !" });
            }
            var VerifiedUserId = tokenService.VerifyTokenAndGetId(token);

            if (Guid.Empty != VerifiedUserId)
            {
                return StatusCode(200, new { message = "Verified Succesfully", payload = VerifiedUserId });
            }
            else
            {
                return StatusCode(403, new { message = "Forbidden to access !" });
            }
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
