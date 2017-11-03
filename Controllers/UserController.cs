using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using splunge-cookie.Models;

namespace splunge-cookie.Controllers
{
    public class UserController : Controller
    {
        private BrightContext _context;

        public UserController(BrightContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("main")]
        public IActionResult Main()
        {
            return View();
        }
    }
}