using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Data;
using P2WebMVC.Models.DomainModels;
using P2WebMVC.Models.ViewModels;
using P2WebMVC.Types;

namespace P2WebMVC.Controllers
{
  public class ProductController : Controller
  {


    private readonly SqlDbContext dbContext;


    public ProductController(SqlDbContext dbContext)
    {
      this.dbContext = dbContext;
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
    public async Task <IActionResult> Details (Guid ProductId){


      try
      {
        
        var product = await dbContext.Products.FindAsync(ProductId);


      var viewModel = new ProductView{
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
    public async Task <IActionResult> AddToCart (Guid ProductId,  string? Color , int Qunatity , string? Size ){


      try
      {
        
        var product = await dbContext.Products.FindAsync(ProductId);


     

        return View();    


      }
      catch (System.Exception ex)
      {

        ViewBag.ErrorMessage = ex.Message;
        return View("Error");
       
      }



    }






  }
}
