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
    public class ClientsController : Controller
    {
        private NorthWestLabsContext db = new NorthWestLabsContext();

        [ActionName("ClientHome")]
        public ActionResult ClientHome(Client User)
        {
            ViewBag.CurrentUser = User;
            return View(User);
        }

        [ActionName("ClientHome2")]
        public ActionResult ClientHome(int? id)
        {
            Client User = db.Clients.Find(id);
            return View("ClientHome", User);
        }

        // CLIENT INFO STUFF
        // CLIENT INFO STUFF
        // CLIENT INFO STUFF
        // CLIENT INFO STUFF
        public ActionResult ViewProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client User = db.Clients.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }

            return View(User);
        }

        [HttpGet]
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client User = db.Clients.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "ClientID,ClFName,ClLName,CompanyName,ClAddress1,ClAddress2,ClEmail,ClPhone,BankAccouNum,Password,ClStatus")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClientHome", client);
            }
            return View(client);
        }


        // WORK ORDER STUFF
        // WORK ORDER STUFF
        // WORK ORDER STUFF
        // WORK ORDER STUFF
        public ActionResult ViewOrders(int? id)
        {
            ViewBag.clID = id;

            Client client = db.Clients.Find(id);

            IEnumerable<WorkOrder> orders =
                   db.Database.SqlQuery<WorkOrder>
                   ("SELECT * " +
                    "FROM WorkOrders " +
                    "WHERE ClientID = '" + client.ClientID + "'");

            return View(orders);
        }

        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder WorkOrder = db.WorkOrders.Find(id);
            if (WorkOrder == null)
            {
                return HttpNotFound();
            }
            return View(WorkOrder);
        }

        [HttpGet]
        public ActionResult CreateOrder(int? id)
        {
            ViewBag.clID = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder([Bind(Include = "WrkOrderID,DueDate,RushOrder,Comments,ClientID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();

                int? OldId = workOrder.ClientID;

                return RedirectToAction("ViewOrders", new { id = OldId });
            }           

            return View(workOrder);
        }

                                      
        // Not sure what this is
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
