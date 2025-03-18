using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller   // inheritance
    {



        public IActionResult Index()
        {
            return View();     // return view of /home/Index.cshtml

        }


        public IActionResult Privacy()
        {
            return View();    // return view of /home/Privacy.cshtml

        }


          public IActionResult About()
        {
            return View();    // return view of /home/About.cshtml

        }






    }
}
