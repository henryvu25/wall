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
    public class WallController : Controller
    {
        private WallContext _context;

        public WallController(WallContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("display")]
        public IActionResult Display()
        {
            int? currId = HttpContext.Session.GetInt32("currUser");
            User currUser = _context.users.SingleOrDefault(user => user.id == currId);
            List<Message> allMess = _context.messages.ToList();
            ViewBag.user = currUser;
            ViewBag.messages = allMess;
            return View();
        }
        [HttpPost]
        [Route("message")]
        public IActionResult Message(string message)
        {
            int? currId = HttpContext.Session.GetInt32("currUser");
            Message newMess = new Message
            {
                message = message,
                users_id = currId
            };
            _context.Add(newMess);
            _context.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}