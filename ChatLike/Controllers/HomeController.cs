using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatLike.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatLike.Controllers
{
    public class HomeController : Controller
    {
        private ChatContext db;
        public HomeController(ChatContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View( db.Messages.ToList());
        }
        [HttpPost]
        public IActionResult Index(Message mes)
        {
           
            
                db.Messages.Add(mes);
                db.SaveChanges();
                return View(db.Messages.ToList());
        }
      
    
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
