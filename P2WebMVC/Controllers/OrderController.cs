using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Data;
using P2WebMVC.Interfaces;
using P2WebMVC.Models.ViewModels;

namespace P2WebMVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController

        private readonly SqlDbContext dbContext;    // encapsulated feilds
        private readonly ITokenService tokenService;

        public OrderController(SqlDbContext dbContext, ITokenService tokenService)
        {
            this.dbContext = dbContext;
            this.tokenService = tokenService;
        }


        [HttpGet]
        public async Task<ActionResult> CheckOut(Guid CartId)
        {
            var token = Request.Cookies["GradSchoolAuthorizationToken"];
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "User");


            var userId = tokenService.VerifyTokenAndGetId(token);

            if (userId == Guid.Empty)
                return RedirectToAction("Login", "User");



                // list // in future 
            var address = await dbContext.Addresses.FirstOrDefaultAsync(a => a.UserId == userId); // slow   // n log n 


            var cart = await dbContext.Carts.FindAsync(CartId);// fast    O(1)


            if (cart == null)
            {
                ViewBag.errorMessage = "No Cart Found!";
                return View();
            }


        
            var viewmodel = new CartView
            {

                Cart = cart,
                Address = address

            };

            return View(viewmodel);

        }


        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

    }
}
