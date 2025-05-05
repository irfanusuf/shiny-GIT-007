using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Data;
using P2WebMVC.Interfaces;
using P2WebMVC.Models.DomainModels;
using P2WebMVC.Models.JunctionModels;
using P2WebMVC.Models.ViewModels;
using P2WebMVC.Types;

namespace P2WebMVC.Controllers
{
  public class ProductController : Controller
  {


    private readonly SqlDbContext dbContext;

    private readonly ITokenService tokenService;


    public ProductController(SqlDbContext dbContext, ITokenService tokenService)
    {
      this.dbContext = dbContext;
      this.tokenService = tokenService;
    }

    // GET: ProductController

    [HttpGet]
    public async Task<ActionResult> Index(ProductCategory category)
    {


      try
      {

        if (category == ProductCategory.General)
        {

          var products = await dbContext.Products.Where(p => p.IsActive == true).ToListAsync();  // db query 

          if (products == null || products.Count == 0)
          {

            ViewBag.Message = "No products Available!";
            ViewBag.Category = category;
            return View();

          }
          else
          {

            var viewModel = new ProductView
            {
              Products = products
            };

            ViewBag.Category = category;
            return View(viewModel);

          }
        }
        else
        {



          var products = await dbContext.Products.Where(p => p.IsActive == true && p.Category == category).ToListAsync();  // db query 

          if (products == null || products.Count == 0)
          {

            ViewBag.Message = "No products Available!";
            ViewBag.Category = category;
            return View();

          }
          else
          {

            var viewModel = new ProductView
            {
              Products = products
            };

            ViewBag.Category = category;
            return View(viewModel);

          }


        }







      }
      catch (System.Exception ex)
      {
        ViewBag.ErrorMessage = ex.Message;
        return View("Error");
        throw;
      }

    }



    [HttpGet]
    public async Task<IActionResult> Details(Guid ProductId)
    {


      try
      {

        var product = await dbContext.Products.FindAsync(ProductId);


        var viewModel = new ProductView
        {
          Product = product

        };

        return View(viewModel);    //empty view // after passing the view model view now has data 


      }
      catch (System.Exception ex)
      {

        ViewBag.ErrorMessage = ex.Message;
        return View("Error");

      }



    }



    [HttpPost]
    public async Task<IActionResult> AddToCart(Guid ProductId, string? Color, int Qunatity, string? Size)
    {


      try
      {
        // token fetch from cookies 
        var token = Request.Cookies["GradSchoolAuthorizationToken"];
        // not token 
        var product = await dbContext.Products.FindAsync(ProductId);

        if (product == null)
        {

        }

        if (token == null)
        {
          RedirectToAction("login", "user");
        }

        // user id 
        var userId = tokenService.VerifyTokenAndGetId(token);

        if (Guid.Empty == userId)
        {
          RedirectToAction("login", "user");
        }

        var cart = await dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);


        if (cart == null)
        {

          cart = new Cart
          {
            UserId = userId,
            CartTotal = 0

          };
        }

        var existingCartItems = await dbContext.CartProducts.Where(cp => cp.CartId == cart.CartId).ToListAsync();

        if (existingCartItems == null)
        {

          var cartItem = new CartProduct
          {

            CartId = cart.CartId,
            ProductId = ProductId,
            Quantity = Qunatity,
            Color = Color,
            Size = Size
          };

          cart?.Products?.Add(cartItem);

          cart?.CartTotal = product?.ProductPrice * Qunatity;

          await dbContext.SaveChangesAsync();



        }
        else
        {


          cart.CartTotal = product.ProductPrice;
          await dbContext.SaveChangesAsync();

        }

        // find product 


        // product color // size // weight  // qty // paramerters


        // find cart 

        return RedirectToAction("Cart" , "User");


      }
      catch (System.Exception ex)
      {

        ViewBag.ErrorMessage = ex.Message;
        return View("Error");

      }



    }









  }
}
