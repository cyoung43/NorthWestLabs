using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using NorthWestLabs.DAL;
using NorthWestLabs.Models;

namespace NorthWestLabs.Controllers
{
    [Authorize]
    public class SingaporeController : Controller
    {
        private NorthWestLabsContext db = new NorthWestLabsContext();

        public ActionResult SingaporeHome()
        {
            return View();
        }

        public ActionResult SeeQuotes()
        {
            return View(HomeController.Quotes);
        }

        [HttpGet]
        public ActionResult AssignPrice(int? id)
        {
            AddQuote addQuote = HomeController.Quotes.Find(x => x.QCode == id);

            return View(addQuote);
        }

        [HttpPost]
        public ActionResult AssignPrice(AddQuote addQuote)
        {
            if (addQuote.TotalPrice == 0)
            {
                ViewBag.TotalPrice = "Please enter the estimated price.";
                return View(addQuote);
            }

            var obj = HomeController.Quotes.FirstOrDefault(x => x.QCode == addQuote.QCode);

            if (obj != null)
            {
                obj.TotalPrice = addQuote.TotalPrice;
                obj.DayNum = addQuote.DayNum;
            }

            return RedirectToAction("InformCustomer", addQuote);
        }

        public ActionResult InformCustomer(AddQuote finishedQuote)
        {
            string body = finishedQuote.FullName + ", <br><br>Thank you for your interest in Northwest Labs. Your requested price quote is an estimated $" + finishedQuote.TotalPrice + " " +
                "based on your selected tests.<br><br> If you have further questions, please contact our Seattle office at 555-231-7589<br><br>Gary Anderson<br> Northwest Labs Singapore";

            //set up email message
            MailMessage mail = new MailMessage();
            mail.To.Add(finishedQuote.Email);
            mail.From = new MailAddress("northwestlabspricing@gmail.com");
            mail.Subject = "Your Requested Quote";
            mail.Body = body;
            mail.IsBodyHtml = true;

            //set up smtp client
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("northwestlabspricing", "Northwest01");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            HomeController.Quotes.Remove(HomeController.Quotes.FirstOrDefault(x => x.QCode == finishedQuote.QCode));
            return RedirectToAction("CurrentQuotes", new { result = "Quote results sent."});
        }

        public ActionResult CurrentQuotes(string result)
        {
            ViewBag.Result = result;

            int quoteCount = HomeController.Quotes.Count();
            string request;
        
            if (quoteCount > 1 || quoteCount == 0)
            {
                request = "requests";
            }
            else
            {
                request = "request";
            }

            ViewBag.Count = "You have " + quoteCount + " new quote " + request;
            return View();
        }

        public ActionResult ListWorkOrder()
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = SeattleController.testStatus;
            ViewBag.Employees = db.Employees.ToList();

            return View(db.WorkOrders.ToList());
        }

        [HttpGet]
        public ActionResult EditWorkOrder(int? id)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = SeattleController.testStatus;
            ViewBag.Employees = db.Employees.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: Seattle/EditWorkOrder/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWorkOrder([Bind(Include = "WrkOrdID,ReceivedDate,DueDate,RushedOrder,Comments,WOReport,ReceivedBy,ClientID,SummaryStatus")] WorkOrder workOrder)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = SeattleController.testStatus;
            ViewBag.Employees = db.Employees.ToList();

            if (workOrder.ReceivedDate != null)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListWorkOrder");
            }
            return View(workOrder);
        }

        // GET: Seattle/WorkOrderDetails
        public ActionResult WorkOrderDetails(int? id)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = SeattleController.testStatus;
            ViewBag.Employees = db.Employees.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
