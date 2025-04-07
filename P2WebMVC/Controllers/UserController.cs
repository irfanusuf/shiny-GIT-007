using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2WebMVC.Data;
using P2WebMVC.Models;
using P2WebMVC.Models.ViewModels;

namespace P2WebMVC.Controllers
{
    public class UserController : Controller
    {

        private readonly SqlDbContext sqlDbContext;    // encapsulated feilds

        public UserController(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.errorMessage = "All details Required!";
                    return View();
                }
                //   var existingUser = await sqlDbContext.Users.FindAsync(user.UserId);   // findAsync is for PK

                var existingUser = await sqlDbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);   // findAsync is for PK

                if (existingUser != null)
                {

                    ViewBag.errorMessage = "User Already Exists";
                    return View();

                }

                var encryptPass = BCrypt.Net.BCrypt.HashPassword(user.Password);

                user.Password = encryptPass;



                var newUser = await sqlDbContext.Users.AddAsync(user);
                await sqlDbContext.SaveChangesAsync();


                // ViewBag.successMessage = "User Created Succefully!";

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View("Error");
            }


        }




        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]

        public async Task<ActionResult> Login(LoginView user)
        {

            try
            {

                if (!ModelState.IsValid)
                {
                    ViewBag.errorMessage = "All credentials Required!";
                    return View();
                }

                var existingUser = await sqlDbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);


                if (existingUser == null)
                {

                    ViewBag.errorMessage = "User not Found!";
                    return View();

                }

                var checkPass = BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password);

                if (checkPass)
                {


                    return RedirectToAction("Dashboard", "Admin");

                }
                else
                {
                    ViewBag.errorMessage = "PassWord incorrect!";
                    return View();
                }




            }
            catch (Exception ex)
            {

                ViewBag.errorMessage = ex.Message;
                return View("Error");
            }




        }


    }
}





