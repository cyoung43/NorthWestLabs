using NorthWestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWestLabs.Controllers
{
    public class HomeController : Controller
    {
        private NorthWestLabsContext db = new NorthWestLabsContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Pricing()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogInClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogInClient(FormCollection UserInfo)
        { 

            

            return RedirectToAction("Index", "Seattle");
        }

        public ActionResult CreateProfile()
        {
            return View();
        }
    }
}