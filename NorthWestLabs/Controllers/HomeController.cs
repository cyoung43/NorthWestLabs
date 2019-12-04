using NorthWestLabs.DAL;
using NorthWestLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthWestLabs.Controllers
{
    public class HomeController : Controller
    {
        private NorthWestLabsContext db = new NorthWestLabsContext();

        public List<ClientStatus> Status = new List<ClientStatus>();

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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            var currentUser =
                db.Database.SqlQuery<Client>(
            "Select * " +
            "FROM Clients " +
            "WHERE ClEmail = '" + email + "' AND " +
            "Password = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                
                return RedirectToAction("Index", "Clients");

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(Client client)
        {


            return RedirectToAction("Login");
        }
    }
}