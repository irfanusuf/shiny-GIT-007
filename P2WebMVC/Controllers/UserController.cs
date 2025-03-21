using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Data;
using P2WebMVC.Models;

namespace P2WebMVC.Controllers
{
    public class UserController : Controller
    {

        private readonly SqlDbContext sqlDbContext;    // encapsulated feilds

        public UserController(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext  = sqlDbContext;
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
         public async Task<ActionResult> Register(User model)
        {
            // register logic
            if(!ModelState.IsValid){

                ViewBag.errorMessage ="All the input feilds are required!" ;
                 return View();
            }

            var user = await sqlDbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if(user != null){

                ViewBag.errorMessage ="User Already Exists!" ;
                 return View();

            }

            await sqlDbContext.Users.AddAsync(model);
            await sqlDbContext.SaveChangesAsync();

            ViewBag.successMessage ="User created Succesfully!" ;

            return View();
        }



          public ActionResult Login()
        {
            return View();
        }

    }
}
