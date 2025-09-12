using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P0_ClassLibrary.Interfaces;
using P5_WebApi.Data;
using P5_WebApi.Models.DomainModels;
using P5_WebApi.Models.JunctionModels;

namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {


        private readonly SqlDbContext sqlDb;
        private readonly ITokenService tokenService;
        public CartController(SqlDbContext dbContext, ITokenService tokenService)
        {
            sqlDb = dbContext;
            this.tokenService = tokenService;

        }


        // [Authorize]
        [HttpPost("addtocart")]
        public async Task<ActionResult> AddtoCart(Guid productId, int qty)
        {

            try
            {
                var token = HttpContext.Request.Cookies["Authorization_Token_React"];

                if (string.IsNullOrEmpty(token))
                {
                    return StatusCode(403, new { message = "Session Expired .kindly Login again ! " });
                }


                var userId = tokenService.VerifyTokenAndGetId(token);

                if (userId == Guid.Empty)
                {
                    return Unauthorized(new { message = "Unauthorized to access , kindly login again !" });
                }


                var product = await sqlDb.Products.FindAsync(productId);

                if (product == null)
                {
                    return NotFound(new { message = "Product not found !" });
                }

                var cart = await sqlDb.Carts.FirstOrDefaultAsync(cart => cart.UserId == userId);


                // if (cart == null)
                // {
                //     return NotFound(new { message = "cart not found" });
                // }

                if (cart == null)
                {

                    var newCart = new Cart
                    {
                        UserId = userId,
                        CartTotal = product.ProductPrice * qty
                    };


                    var CartProducts = new CartProduct
                    {
                        CartId = newCart.CartId,
                        ProductId = productId,
                        Quantity = qty,
                    };

                    newCart.CartProducts = [CartProducts];


                    await sqlDb.Carts.AddAsync(newCart);
                    await sqlDb.SaveChangesAsync();



                    return Ok(new { message = "cart created", payload = newCart });
                }
                else
                {

                    // updation pending

                    return Ok(new { messsage = "Cart updated succesfully", payload = cart });

                }


            }
            catch (System.Exception)
            {

                throw;
            }

        }





    }
}
