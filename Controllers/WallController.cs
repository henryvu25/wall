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
            int? currId = HttpContext.Session.GetInt32("currId");
            if(currId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User currUser = _context.users.Where(user => user.userid == currId).SingleOrDefault();
            List<Message> allMess = _context.messages.OrderByDescending(m => m.messageid)
                       .Include(mess => mess.user).Include(mess => mess.comments)
                       .ToList();
            ViewBag.user = currUser;
            ViewBag.messages = allMess;
            return View();
        }
        [HttpPost]
        [Route("message")]
        public IActionResult Message(string message)
        {
            int? currId = HttpContext.Session.GetInt32("currId");
            Message newMess = new Message
            {
                message = message,
                userid = currId
            };
            _context.Add(newMess);
            _context.SaveChanges();
            return RedirectToAction("Display");
        }
        [HttpPost]
        [Route("comment")]
        public IActionResult Comment(string comment, int messageid)
        {
            int? currId = HttpContext.Session.GetInt32("currId");
            Comment newCom = new Comment
            {
                comment = comment,
                userid = currId,
                messageid = messageid
            };
            _context.Add(newCom);
            _context.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}