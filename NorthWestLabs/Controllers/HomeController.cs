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

        [HttpGet]
        public ActionResult ClLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClLogin(FormCollection form, bool rememberMe = false)
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
        public ActionResult EmpLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmpLogin(FormCollection form, bool rememberMe = false)
        {
            String empID = form["Employee ID"].ToString();
            String password = form["Password"].ToString();
            String location = form["Location"].ToString();

            var currentUser =
                db.Database.SqlQuery<Employee>(
            "Select * " +
            "FROM Employees " +
            "WHERE EmpID = '" + empID + "' AND " +
            "EmpPassword = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(empID, rememberMe);

                if (location == "1")
                {
                    return RedirectToAction("Index", "Singapore");
                }
                else if (location == "2")
                {
                    return RedirectToAction("Index", "Seattle");
                }
                else
                {
                    return View();
                }

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
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile([Bind(Include = "ClientID,ClFName,ClLName,CompanyName,ClAddress1,ClAddress2,ClEmail,ClPhone,BankAccouNum,Password,ClStatus")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Clients");
            }

            return View(client);
        }

        public ActionResult ViewClients()
        {
            return View(db.Clients.ToList());
        }
    }
}