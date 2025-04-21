using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P2WebMVC.Data;
using P2WebMVC.Interfaces;
using P2WebMVC.Models.DomainModels;

namespace P2WebMVC.Controllers
{
    public class AdminController : Controller
    {

      private readonly SqlDbContext dbContext;    // encapsulated feilds
        private readonly ITokenService tokenService;

        public AdminController(ITokenService tokenService , SqlDbContext dbContext)
        {
            this.tokenService = tokenService;
            this.dbContext = dbContext;
        }



        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Dashboard()
        {

            var token = Request.Cookies["GradSchoolAuthorizationToken"];

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("login", "user");
            }


            var userId = tokenService.VerifyTokenAndGetId(token);

            if (userId == null)
            {
                return RedirectToAction("login", "user");
            }



            return View();
        }



        [HttpGet]
        public ActionResult Createproduct()
        {


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Createproduct(Product req)
        {

            try
            {
                if (string.IsNullOrEmpty(req.ProductName) || 
                string.IsNullOrEmpty(req.ProductDescription) || 
                string.IsNullOrEmpty(req.ProductImage))
                {
                    ViewBag.ErrorMessage = "All details with * are required";
                    return View();
                }

                await dbContext.Products.AddAsync(req);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Dashboard");

            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
                throw;
            }

        }
    }
}
