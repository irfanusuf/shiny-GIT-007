using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Data;
using P2WebMVC.Interfaces;
using P2WebMVC.Models.DomainModels;
using P2WebMVC.Models.JunctionModels;
using P2WebMVC.Models.ViewModels;

namespace P2WebMVC.Controllers
{
    public class OrderController : Controller
    {

        private readonly SqlDbContext dbContext;    // encapsulated feilds
        private readonly ITokenService tokenService;

        public OrderController(SqlDbContext dbContext, ITokenService tokenService)
        {
            this.dbContext = dbContext;
            this.tokenService = tokenService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> CheckOut(Guid CartId)
        {
       

            Guid? userId = HttpContext.Items["UserId"] as Guid?;
            // list // in future 
            var address = await dbContext.Addresses.FirstOrDefaultAsync(a => a.UserId == userId); // slow   // n log n 
            var cart = await dbContext.Carts.FindAsync(CartId);// fast    O(1)

            if (cart != null )
            {
                var cartProducts = await dbContext.CartProducts.Include(cp => cp.Product).Where(cp => cp.CartId == cart.CartId).ToListAsync();
                var viewmodel = new CartView
                {
                    Cart = cart,
                    Address = address,
                    CartProducts = cartProducts
                };
                return View(viewmodel);
            }
            ViewBag.errorMessage = "No Cart Found!";
            return View();
        }



        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Create(Guid CartId)
        {
            try
            {
                  Guid? userId = HttpContext.Items["UserId"] as Guid?;

                var address = await dbContext.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);

                var cart = await dbContext.Carts
                    .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                    .FirstOrDefaultAsync(c => c.CartId == CartId);

                if (cart != null && address != null && cart.CartProducts.Count > 0)
                {
                    var order = new Order
                    {
                        UserId = (Guid)userId,
                        TotalPrice = cart.CartTotal,
                        AddressId = address.AddressId,
                        OrderProducts = [],
                        OrderStatus = Types.OrderStatus.Pending
                    };

                    var orderProducts = cart.CartProducts.Select(cp => new OrderProduct
                    {
                        OrderId = order.OrderId,
                        ProductId = cp.ProductId,
                        Quantity = cp.Quantity,
                        Size = cp.Size,
                        Color = cp.Color,
                        Weight = cp.Weight
                    }).ToList();

                    order.OrderProducts = orderProducts;

                    await dbContext.Orders.AddAsync(order);

                    if (cart?.CartProducts != null)
                    {
                        dbContext.CartProducts.RemoveRange(cart.CartProducts);
                        cart.CartTotal = 0;
                    }

                    await dbContext.SaveChangesAsync();


                    TempData["SuccessMessage"] = "order created Succesfully";
                    return RedirectToAction("CheckOut", "Order", new { CartId });
                }
                else
                {
                    TempData["ErrorMessage"] = "Some Error with Cart!.Try again!";
                    return RedirectToAction("checkout", new { CartId });
                }

            }
            catch (System.Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View("Error");
                throw;
            }

        }

    }
}
