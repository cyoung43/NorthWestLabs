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
    [Authorize]
    public class SeattleController : Controller
    {
        //set up client status list
        public static List<ClientStatus> ClientStatus = new List<ClientStatus>()
        {
            new ClientStatus{statusCode = "A", statusDesc = "Active"},
            new ClientStatus{statusCode = "U", statusDesc = "New Client"}
        };

        //Set up test status list
        public static List<TestStatus> testStatus = new List<TestStatus>()
        {
            new TestStatus{StatusDesc = "Work Order Received"},
            new TestStatus{StatusDesc = "Tests Started"},
            new TestStatus{StatusDesc = "Tests in Progress"},
            new TestStatus{StatusDesc = "Tests Completed"},
            new TestStatus{StatusDesc = "Tests Results Sent"}
        };

        private NorthWestLabsContext db = new NorthWestLabsContext();

        public ActionResult SeattleHome()
        {
            return View();
        }


         /*
         ///////////////////////////////////////////////
         Client Methods
         //////////////////////////////////////////////    
         */

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
            ViewBag.Status = ClientStatus;
            return View();
        }

        // POST: Seattle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,ClFName,ClLName,CompanyName,ClAddress1,ClAddress2,ClEmail,ClPhone,BankAccouNum,Password,ClStatus,BankID,DisID")] Client client)
        {
            //set up clients for viewbags
            ViewBag.Banks = db.Banks.ToList();
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
        public ActionResult Edit([Bind(Include = "ClientID,ClFName,ClLName,CompanyName,ClAddress1,ClAddress2,ClEmail,ClPhone,BankAccouNum,Password,ClStatus,BankID,DisID")] Client client)
        {
            //set up viewbags for editing client
            ViewBag.Banks = db.Banks.ToList();
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
            ViewBag.Employees = db.Employees.ToList();
            return View(db.WorkOrders.ToList());
        }

        // GET: Seattle/WorkOrderDetails
        public ActionResult WorkOrderDetails(int? id)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;
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

        // GET: Seattle/Create
        public ActionResult WorkOrderCreate()
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;
            ViewBag.Employees = db.Employees.ToList();
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
            ViewBag.Employees = db.Employees.ToList();

            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();

                return RedirectToAction("WorkIndex");
            }

            return View(workOrder);
        }

        // GET: Seattle/Edit/5
        public ActionResult WorkOrderEdit(int? id)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;
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
        public ActionResult WorkOrderEdit([Bind(Include = "WrkOrdID,ReceivedDate,DueDate,RushedOrder,Comments,WOReport,ReceivedBy,ClientID,SummaryStatus")] WorkOrder workOrder)
        {
            ViewBag.Clients = db.Clients.ToList();
            ViewBag.Summary = testStatus;
            ViewBag.Employees = db.Employees.ToList();

            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WorkIndex");
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
            return RedirectToAction("WorkIndex");
        }

         /*
         ///////////////////////////////////////////////
         Employee Methods
         ///////////////////////////////////////////////    
         */

        public ActionResult EmployeeIndex()
        {
            ViewBag.Position = db.EmployeeTypes.ToList();
            return View(db.Employees.ToList());
        }

        // GET: Seattle/WorkOrderDetails
        public ActionResult EmployeeDetails(int? id)
        {
            ViewBag.Position = db.EmployeeTypes.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Seattle/Create
        public ActionResult EmployeeCreate()
        {
            ViewBag.Position = db.EmployeeTypes.ToList();
            return View();
        }

        // POST: Seattle/WorkOrderCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeCreate([Bind(Include = "EmpID,EmpFName,EmpLName,EmpWage,EmpPassword,EmpType")] Employee employee)
        {
            ViewBag.Position = db.EmployeeTypes.ToList();

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("EmployeeIndex");
            }

            return View(employee);
        }

        // GET: Seattle/Edit/5
        public ActionResult EmployeeEdit(int? id)
        {
            ViewBag.Position = db.EmployeeTypes.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Seattle/EditWorkOrder/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeEdit([Bind(Include = "EmpID,EmpFName,EmpLName,EmpWage,EmpPassword,EmpType")] Employee employee)
        {
            ViewBag.Position = db.EmployeeTypes.ToList();

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeeIndex");
            }
            return View(employee);
        }

        // GET: Seattle/Delete/5
        public ActionResult EmployeeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Seattle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeDeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("EmployeeIndex");
        }

        public ActionResult SeeQuotes()
        {
            return View(ClientsController.Quotes);
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
