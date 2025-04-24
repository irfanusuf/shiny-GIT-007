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

        private readonly ICloudinaryService cloudinaryService;

        public AdminController(ITokenService tokenService, SqlDbContext dbContext , ICloudinaryService cloudinaryService)
        {
            this.tokenService = tokenService;
            this.dbContext = dbContext;
            this.cloudinaryService = cloudinaryService;
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
        public async Task<ActionResult> Createproduct(Product req, IFormFile file)
        {

            try
            {

                if (file == null || file.Length == 0)
                {
                    ViewBag.ErrorMessage = "Kindly Select the image File";
                    return View();
                }

                var SecureUrl = await cloudinaryService.UploadImage(file);


                if (string.IsNullOrEmpty(req.ProductName) ||
                string.IsNullOrEmpty(req.ProductDescription))
                // string.IsNullOrEmpty(req.ProductImage))
                {
                    ViewBag.ErrorMessage = "All details with * are required";
                    return View();
                }


                req.ProductImage = SecureUrl;

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
