using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using splungecookie.Models;
using Microsoft.EntityFrameworkCore;

namespace splungecookie.Controllers
{
    public class IdeaController : Controller
    {
        private BrightContext _context;
        public IdeaController(BrightContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("bright_ideas")]
        public IActionResult Ideas()
        {
            if(HttpContext.Session.GetInt32("userid") != null)
            {
                ViewBag.alias = HttpContext.Session.GetString("alias");
                ViewBag.ideas = _context.Ideas.Include(idea => idea.user).ToList();
                return View();
            } else
            {
                return RedirectToAction("Main");
            }
        }

        [HttpPost]
        [Route("postidea")]
        public IActionResult PostIdea(IdeaViewModel idea)
        {
            if(ModelState.IsValid)
            {
                if(HttpContext.Session.GetInt32("userid") != null)
                {
                    int uid = (int)HttpContext.Session.GetInt32("userid");
                    Idea NewIdea = new Idea();
                    User user = _context.Users.SingleOrDefault(login => login.userid == uid);
                    NewIdea.user = user;
                    NewIdea.text = idea.text;
                    NewIdea.created_at = DateTime.Now;
                    NewIdea.updated_at = DateTime.Now;
                    _context.Ideas.Add(NewIdea);
                    _context.SaveChanges();
                    return RedirectToAction("Ideas");
                }
                else
                {
                    return RedirectToAction("Main");
                }
            }
            else
            {
                return View("~/Views/Idea/Ideas.cshtml", idea);
            }
        }

        // [HttpPost]
        // [Route("Idea/postidea")]
        // public IActionResult IdeaPostRedir()
        // {
        //     return RedirectToAction("PostIdea");
        // }


        [HttpGet]
        [Route("User/bright_ideas")]
        public IActionResult IdeaRedir()
        {
            return RedirectToAction("Ideas");
        }
    }
}