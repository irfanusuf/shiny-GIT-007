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
            { // fetch token
                var token = HttpContext.Request.Cookies["Authorization_Token_React"];

                if (string.IsNullOrEmpty(token))
                {
                    return StatusCode(403, new { message = "Session Expired .kindly Login again ! " });
                }

                // verify token 
                var userId = tokenService.VerifyTokenAndGetId(token);

                if (userId == Guid.Empty)
                {
                    return Unauthorized(new { message = "Unauthorized to access , kindly login again !" });
                }

                // finding product with its id
                var product = await sqlDb.Products.FindAsync(productId);

                if (product == null)
                {
                    return NotFound(new { message = "Product not found !" });
                }

                // var user = await sqlDb.Users.Include(user => user.Cart).ThenInclude(cart => cart.CartProducts).FirstOrDefaultAsync(user => user.UserId == userId);

                var cart = await sqlDb.Carts.Include(cart => cart.CartProducts).FirstOrDefaultAsync(cart => cart.UserId == userId);

                if (cart == null)
                {
                    var newCart = new Cart
                    {
                        UserId = userId,
                        CartTotal = product.ProductPrice * qty
                    };

                    var cartProduct = new CartProduct
                    {
                        CartId = newCart.CartId,
                        ProductId = productId,
                        Quantity = qty,
                    };

                    await sqlDb.Carts.AddAsync(newCart);
                    await sqlDb.CartProducts.AddAsync(cartProduct);

                    await sqlDb.SaveChangesAsync();
                    return Ok(new { message = "cart created", payload = newCart });
                }
                else
                {
                    var existingCartProduct = await sqlDb.CartProducts.FirstOrDefaultAsync(cp => cp.ProductId == productId && cp.CartId == cart.CartId);
                    if (existingCartProduct != null)
                    {

                        existingCartProduct.Quantity += qty;
                    }
                    else
                    {
                        var cartProduct = new CartProduct
                        {
                            CartId = cart.CartId,
                            ProductId = productId,
                            Quantity = qty

                        };


                        await sqlDb.CartProducts.AddAsync(cartProduct);
                    }


                    cart.CartTotal += product.ProductPrice * qty;
                    await sqlDb.SaveChangesAsync();
                    // updation pending

                    return Ok(new { messsage = "Cart updated succesfully", payload = cart });
                }
            }
            catch (System.Exception)
            {
                throw;
            }

        }



        public async Task<ActionResult> RemovefromCart(Guid productid)
        {



            try
            {
                var token = HttpContext.Request.Cookies["Auth_token"];

                if (token == null)
                {
                    return StatusCode(403, new { message = "please login" });
                }

                var userId = tokenService.VerifyTokenAndGetId(token);
                if (userId == Guid.Empty)
                {
                    return StatusCode(404, new { message = "please login" });
                }

                var cart = await sqlDb.Carts.FirstOrDefaultAsync(cart => cart.UserId == userId);


                if (cart.CartProducts.Where(cp => cp.ProductId == productid) != null)
                {

                }
                //var product = sqlDb.Products.FindAsync(productid);

                //var cartproduct = await sqlDb.CartProducts.FirstOrDefaultAsync(cp => cp.ProductId == productid);


            }
            catch (System.Exception)
            {

                throw;
            }


            return Ok();

        }




    }
}
