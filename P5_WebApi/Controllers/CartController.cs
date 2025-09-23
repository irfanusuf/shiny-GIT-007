
using CloudinaryDotNet.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P0_ClassLibrary.Interfaces;
using P5_WebApi.Data;
using P5_WebApi.Middlewares;
using P5_WebApi.Models.DomainModels;
using P5_WebApi.Models.JunctionModels;

namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly SqlDbContext sqlDb;
        private readonly ITokenService tokenService;
        public CartController(SqlDbContext dbContext, ITokenService tokenService)
        {
            sqlDb = dbContext;
            this.tokenService = tokenService;

        }


        [HttpPost("addtocart")]
        public async Task<ActionResult> AddtoCart(Guid productId, int qty)
        {

            try
            { // fetch token


                var userId = Guid.Parse(HttpContext.Items["userId"].ToString());


                // finding product with its id
                var product = await sqlDb.Products.FindAsync(productId);   // O(1)

                if (product == null)
                {
                    return NotFound(new { message = "Product not found !" });
                }

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
                        ProductPrice = product.ProductPrice
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
                            Quantity = qty,
                            ProductPrice = product.ProductPrice

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

        [HttpPost("RemoveFromCart")]
        public async Task<ActionResult> RemovefromCart(Guid productid)
        {
            try
            {
                Guid userId = (Guid)(HttpContext.Items["userId"] as Guid?);

                // cart fetch    // sub query cartproducts fetch
                var cart = await sqlDb.Carts.Include(cart => cart.CartProducts).FirstOrDefaultAsync(cart => cart.UserId == userId);

                if (cart == null)
                {
                    return NotFound(new { message = "Cart not Found !" });
                }


                // buffer // List  // query is very fast 
                var cartproduct = cart.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId && cp.ProductId == productid);

                // async db query slow
                // var cartProduct = await sqlDb.CartProducts.FirstOrDefaultAsync(cp => cp.CartId == cart.CartId && cp.ProductId == productid);


                if (cartproduct == null)
                {
                    return NotFound(new { message = "Cart Item Not Found !" });
                }

                var remove = sqlDb.CartProducts.Remove(cartproduct);

                if (remove != null)
                {

                    cart.CartTotal -= cartproduct.ProductPrice * cartproduct.Quantity;
                    await sqlDb.SaveChangesAsync();

                    return Ok(new { message = "Item removed From the Cart !", payload = cart });
                }
                else
                {
                    return BadRequest(new { message = "Something Went Wrong !" });
                }



            }
            catch (System.Exception)
            {

                throw;
            }




        }
      
        [HttpGet("increaseQuantity")]
        public ActionResult IncreaseQuantity(Guid productId)
        {


            return Ok();
        }

        [HttpGet("decreaseQuantity")]
        public ActionResult DescreaseQuantity(Guid productId)
        {


            return Ok();
        }

        [HttpGet("clearCart")]
        public ActionResult ClearCart(Guid cartId)
        {


            return Ok();
        }

    }
}
