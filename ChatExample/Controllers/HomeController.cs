using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codefirst_Models;
namespace ChatExample.Controllers
{
    public class HomeController : Controller
    {
        private Codefirst_Models.Models dbContext = new Codefirst_Models.Models();
        public ActionResult Index()
        {
            dbContext.ChatSessions.Add(new ChatSession {StartedAt = DateTime.Now});
            dbContext.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}