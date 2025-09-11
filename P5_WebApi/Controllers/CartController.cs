using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P5_WebApi.Data;

namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {


        private readonly SqlDbContext sqlDb;
        private readonly TokenService tokenService;
        public CartController(SqlDbContext dbContext, TokenService tokenService)
        {
            sqlDb = dbContext;
            this.tokenService = tokenService;

        }


        // [Authorize]
        [HttpPost("addtocart")]
        public ActionResult AddtoCart(Guid productId, string token)
        {

            try
            {
                var userId = tokenService.VerifyTokenAndGetId(token);

                if (userId == Guid.Empty)
                {
                    return Unauthorized(new { message = "Unauthorized to access , kindly login again !" });
                }


                return Ok();
            }
            catch (System.Exception)
            {

                throw;
            }

        }





    }
}
