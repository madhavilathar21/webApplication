using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class Company_DetailsController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Company_Details
        public ActionResult Index()
        {
            return View(db.Company_Details.ToList());
        }

        // GET: Company_Details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Details company_Details = db.Company_Details.Find(id);
            if (company_Details == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Create","Post_Job");
            //return View(company_Details);
        }

        // GET: Company_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,PhoneNo,Details_About_Comapny,Email,Password")] Company_Details company_Details)
        {
            if (ModelState.IsValid)
            {
                db.Company_Details.Add(company_Details);
                db.SaveChanges();
                
            }

            //return View(company_Details);
            return RedirectToAction("Create", "Post_Job");
        }

        // GET: Company_Details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Details company_Details = db.Company_Details.Find(id);
            if (company_Details == null)
            {
                return HttpNotFound();
            }
            return View(company_Details);
        }

        // POST: Company_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,PhoneNo,Details_About_Comapny,Email,Password")] Company_Details company_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company_Details);
        }

        // GET: Company_Details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Details company_Details = db.Company_Details.Find(id);
            if (company_Details == null)
            {
                return HttpNotFound();
            }
            return View(company_Details);
        }

        // POST: Company_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Company_Details company_Details = db.Company_Details.Find(id);
            db.Company_Details.Remove(company_Details);
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
