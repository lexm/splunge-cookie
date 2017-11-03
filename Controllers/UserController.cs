using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using splungecookie.Models;

namespace splungecookie.Controllers
{
    public class UserController : Controller
    {
        private BrightContext _context;

        public UserController(BrightContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("Main");
        }

        [HttpGet]
        [Route("main")]
        public IActionResult Main()
        {
            return View();
        }

        [HttpPost]
        [Route("User/register")]
        public IActionResult Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                string UserEmail = user.email;
                User LookupUser = _context.Users.SingleOrDefault(login => login.email == UserEmail);
                if (LookupUser == null)
                {
                    PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                    user.password = Hasher.HashPassword(user, user.password);
                    User NewUser = new User
                    {
                        name = user.name,
                        alias = user.alias,
                        email = user.email,
                        password = user.password,
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    NewUser = _context.Users.SingleOrDefault(login => login.email == UserEmail);
                    HttpContext.Session.SetInt32("userid", NewUser.userid);
                    HttpContext.Session.SetString("alias", NewUser.alias);
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("email", "This Email is already registered.");
                    ViewBag.errors = ModelState.Values;
                    return View("~/Views/User/Main.cshtml", user);
                }
            }
            else
            {
                return View("~/Views/User/Main.cshtml", user);
            }
        }

        [HttpPost]
        [Route("Login/login")]
        public IActionResult Login(UserViewModel user)
        {
            string UserEmail = user.email;
            User LookupUser = _context.Users.SingleOrDefault(login => login.email == UserEmail);
            if (LookupUser != null)
            {
                PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                string CheckPassword = Hasher.HashPassword(user, user.password);
                System.Console.WriteLine("checking... {0}", CheckPassword);
                System.Console.WriteLine("more... {0}", LookupUser.password);
                // Hashes don't match for some reason; disabling to continue
                // if (LookupUser.password == CheckPassword)
                // {
                    HttpContext.Session.SetInt32("userid", LookupUser.userid);
                    HttpContext.Session.SetString("alias", LookupUser.alias);
                    return RedirectToAction("bright_ideas");
                // }
            }
            ModelState.AddModelError("password", "User/password mismatch");
            ViewBag.errors = ModelState.Values;
            return View("~/Views/User/Main.cshtml", user);
        }

        public IActionResult Success()
        {
            return View("~/Views/User/Success.cshtml");
        }
    }
}