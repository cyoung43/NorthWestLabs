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

        public ActionResult Login()
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

            IEnumerable<Client> User = 
                db.Database.SqlQuery<Client>(
            "Select * " +
            "FROM Clients " +
            "WHERE ClEmail = '" + email + "' AND " +
            "Password = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("ClientHome", "Clients", User.FirstOrDefault());

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
            //String location = form["Location"].ToString();

            var currentUser =
                db.Database.SqlQuery<Employee>(
            "SELECT * " +
            "FROM Employees " +
            "WHERE EmpID = '" + empID + "' AND " +
            "EmpPassword = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(empID, rememberMe);

                IEnumerable<Employee> UserLoc =
                    db.Database.SqlQuery<Employee>(
                "SELECT * " +
                "FROM Employees " +
                "WHERE EmpID = '" + empID + "' AND " +
                "EmpPassword = '" + password + "'");

                if (UserLoc.FirstOrDefault().EmpType == 2)
                {
                    return RedirectToAction("SingaporeHome", "Singapore");
                }
                else if (UserLoc.FirstOrDefault().EmpType == 1)
                {
                    return RedirectToAction("SeattleHome", "Seattle");
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
                return RedirectToAction("ClientHome", "Clients", client);
            }

            return View(client);
        }

        public ActionResult ViewClients()
        {
            return View(db.Clients.ToList());
        }

        /*
        ///////////////////////////////////////////////
        Quotes
        //////////////////////////////////////////////    
        */

        public static List<AddQuote> Quotes = new List<AddQuote>();

        [HttpGet]
        public ActionResult AddQuote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuote(AddQuote addQuote)
        {
            if (addQuote.FullName == null || addQuote.FullName == "")
            {
                ViewBag.Validations = "Please enter a name.";
                return View(addQuote);
            }
            else if (addQuote.Email == null || addQuote.Email == "")
            {
                ViewBag.Email = "Please enter your email.";
                return View(addQuote);
            }
            else
            {
                addQuote.QCode = Quotes.Count() + 1;
                Quotes.Add(addQuote);
                return RedirectToAction("About", "Home");
            }

        }
    }
}