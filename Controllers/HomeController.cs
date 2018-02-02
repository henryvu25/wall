using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall_proj.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace wall_proj.Controllers
{
    public class HomeController : Controller
    {
        private WallContext _context;

        public HomeController(WallContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;

            string incorrectLogin = HttpContext.Session.GetString("incorrect");
            ViewBag.incorrect = incorrectLogin;

            string userExists = HttpContext.Session.GetString("existing");
            ViewBag.exists = userExists;
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            User existingUser = _context.users.SingleOrDefault(user => user.email == model.email);

            if (ModelState.IsValid && existingUser == null)
            {
                User newUser = new User
                {
                    first = model.first,
                    last = model.last,
                    email = model.email,
                    password = model.password
                };
                _context.users.Add(newUser);
                _context.SaveChanges();
                User currUser = _context.users.SingleOrDefault(user => user.email == model.email);
                int currId = currUser.userid;
                HttpContext.Session.SetInt32("currId", currId);
                return RedirectToAction("Display", "Wall");
            }
            if(existingUser != null)
            {
                HttpContext.Session.SetString("existing", "Email has already been used");
                return RedirectToAction("Index");
            }
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            User currUser = _context.users.SingleOrDefault(user => user.email == email && user.password == password);
            if (currUser != null)
            {
                int currId = currUser.userid;
                HttpContext.Session.SetInt32("currId", currId);
                return RedirectToAction("Display", "Wall");
            }
            else
            {
                HttpContext.Session.SetString("incorrect", "Email and/or password are incorrect");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
