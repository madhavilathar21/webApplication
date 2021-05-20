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
    public class Apply_JobController : Controller
    {
        private Database1Entities1   db = new Database1Entities1();

        // GET: Apply_Job
        public ActionResult Index()
        {
            return View(db.Apply_Job.ToList());
        }

        // GET: Apply_Job/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply_Job apply_Job = db.Apply_Job.Find(id);
            if (apply_Job == null)
            {
                return HttpNotFound();
            }
            return View(apply_Job);
        }

        // GET: Apply_Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apply_Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AEmail,Job_id,Status")] Apply_Job apply_Job)
        {
            if (ModelState.IsValid)
            {
                db.Apply_Job.Add(apply_Job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apply_Job);
        }

        // GET: Apply_Job/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply_Job apply_Job = db.Apply_Job.Find(id);
            if (apply_Job == null)
            {
                return HttpNotFound();
            }
            return View(apply_Job);
        }

        // POST: Apply_Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AEmail,Job_id,Status")] Apply_Job apply_Job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apply_Job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apply_Job);
        }

        // GET: Apply_Job/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply_Job apply_Job = db.Apply_Job.Find(id);
            if (apply_Job == null)
            {
                return HttpNotFound();
            }
            return View(apply_Job);
        }

        // POST: Apply_Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Apply_Job apply_Job = db.Apply_Job.Find(id);
            db.Apply_Job.Remove(apply_Job);
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
