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
    public class SingaporeController : Controller
    {
        private NorthWestLabsContext db = new NorthWestLabsContext();

        // GET: Singapore
        public ActionResult Index()
        {
            return View(db.WorkOrders.ToList());
        }

        // GET: Singapore/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: Singapore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Singapore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WrkOrdID,ReceivedDate,DueDate,RushOrder,comments,ReceivedBy,WOResult,ClientID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workOrder);
        }

        // GET: Singapore/Edit/5
        public ActionResult Edit(int? id)
        {
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

        // POST: Singapore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WrkOrdID,ReceivedDate,DueDate,RushOrder,comments,ReceivedBy,WOResult,ClientID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrder);
        }

        // GET: Singapore/Delete/5
        public ActionResult Delete(int? id)
        {
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

        // POST: Singapore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            db.WorkOrders.Remove(workOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SeeQuotes()
        {
            return View(ClientsController.Quotes);
        }

        [HttpGet]
        public ActionResult AssignPrice(int? id)
        {
            AddQuote addQuote = ClientsController.Quotes.Find(x => x.QCode == id);

            return View(addQuote);
        }

        [HttpPost]
        public ActionResult AssignPrice(AddQuote addQuote)
        {
            var obj = ClientsController.Quotes.FirstOrDefault(x => x.QCode == addQuote.QCode);

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

            ClientsController.Quotes.Remove(ClientsController.Quotes.FirstOrDefault(x => x.QCode == finishedQuote.QCode));
            return RedirectToAction("CurrentQuotes", new { result = "Quote results sent."});
        }

        public ActionResult CurrentQuotes(string result)
        {
            ViewBag.Result = result;

            int quoteCount = ClientsController.Quotes.Count();
            string request;
        
            if (quoteCount > 1)
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
    }
}
