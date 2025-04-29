using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Data;
using P2WebMVC.Models.ViewModels;

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
        public async Task<ActionResult> Index()
        {


                try
                {
                  var products =  await dbContext.Products.Where(p => p.IsActive == true).ToListAsync();

                  if (products == null || products.Count == 0){

                    ViewBag.Message = "No products Availble";
                    return View();

                  }else{

                    var viewModel = new ProductView{
                            Products = products
                    };

                    return View(viewModel);

                  }

                    
                }
                catch (System.Exception ex)
                {
                    ViewBag.ErrorMessage =  ex.Message;
                    return View("Error");
                    throw;
                }
           
        }

    }
}
