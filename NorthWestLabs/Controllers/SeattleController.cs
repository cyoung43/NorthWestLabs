using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthWestLabs.DAL;
using NorthWestLabs.Models;

namespace NorthWestLabs.Controllers
{
    public class SeattleController : Controller
    {
        //new list
        public static List<ClientStatus> ClientStatus = new List<ClientStatus>()
        {
            new ClientStatus{statusCode = "A", statusDesc = "Active"},
            new ClientStatus{statusCode = "U", statusDesc = "New Client"}
        };

        public static List<TestStatus> testStatus = new List<TestStatus>()
        {
            new TestStatus{StatusDesc = "Work Order Received"},
            new TestStatus{StatusDesc = "Tests Started"},
            new TestStatus{StatusDesc = "Tests in Progress"},
            new TestStatus{StatusDesc = "Tests Completed"},
            new TestStatus{StatusDesc = "Tests Results Sent"}
        };

        private NorthWestLabsContext db = new NorthWestLabsContext();

        // GET: Seattle
        public ActionResult Index()
        {
            //set up viewbags for client
            ViewBag.Banks = db.Banks.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Status = ClientStatus;
            return View(db.Clients.ToList());
        }

        // GET: Seattle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Seattle/Create
        public ActionResult Create()
        {
            //set up viewbags for client
            ViewBag.Banks = db.Banks.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Status = ClientStatus;
            return View();
        }

        // POST: Seattle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,ClFName,ClLName,CompanyName,ClAddress1,ClAddress2,ClEmail,ClPhone,BankAccouNum,ClStatus,BankID,DisID")] Client client)
        {
            //set up clients for viewbags
            ViewBag.Banks = db.Banks.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Status = ClientStatus;

            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Seattle/Edit/5
        public ActionResult Edit(int? id)
        {
            //set up viewbags for clients
            ViewBag.Banks = db.Banks.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Status = ClientStatus;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Seattle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,ClFName,ClLName,CompanyName,ClAddress1,ClAddress2,ClEmail,ClPhone,BankAccouNum,ClStatus,BankID,DisID")] Client client)
        {
            //set up viewbags for editing client
            ViewBag.Banks = db.Banks.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Discounts = db.Discounts.ToList();
            ViewBag.Status = ClientStatus;

            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Seattle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Seattle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*
         ///////////////////////////////////////////////
         Work Order Methods
         //////////////////////////////////////////////    
         */

        public ActionResult WorkIndex()
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;
            return View(db.WorkOrders.ToList());
        }

        // GET: Seattle/WorkOrderDetails
        public ActionResult WorkOrderDetails(int? id)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;
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

        // GET: Seattle/Create
        public ActionResult WorkOrderCreate()
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;
            //set up viewbags for client

            return View();
        }

        // POST: Seattle/WorkOrderCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkOrderCreate([Bind(Include = "WrkOrderID,ReceivedDate,DueDate,RushOrder,Comments,WOReport,ReceivedBy,ClientID,SummaryStatus")] WorkOrder workOrder)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;

            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(workOrder);
        }

        // GET: Seattle/Edit/5
        public ActionResult WorkOrderEdit(int? id)
        {
            //set up viewbags for clients
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;

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
        public ActionResult WorkOrderEdit([Bind(Include = "WrkOrderID,ReceivedDate,DueDate,RushOrder,Comments,WOReport,ReceivedBy,ClientID,SummaryStatus")] WorkOrder workOrder)
        {
            //set up viewbags for editing client
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;

            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrder);
        }

        // GET: Seattle/Delete/5
        public ActionResult WorkOrderDelete(int? id)
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

        // POST: Seattle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult WorkOrderDeleteConfirmed(int id)
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
    }
}
