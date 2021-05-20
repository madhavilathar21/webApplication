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
    public class Trainer_DetailsController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Trainer_Details
        public ActionResult Index()
        {
            return View(db.Trainer_Details.ToList());
        }

        // GET: Trainer_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer_Details trainer_Details = db.Trainer_Details.Find(id);
            if (trainer_Details == null)
            {
                return HttpNotFound();
            }
            return View(trainer_Details);
        }

        // GET: Trainer_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TId,TName,TDOB,TDateofjoin,TSalary,TQualification,TSchedule,TEmail,TPWD")] Trainer_Details trainer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Trainer_Details.Add(trainer_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer_Details);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //    [ValidateAntiForgeryToken]
        public ActionResult Login(Trainer_Details model)
        {
            if (ModelState.IsValid)
            {
                Database1Entities1 db = new Database1Entities1();
                var user = (from Mem_Tab in db.Mem_Tab
                            where Mem_Tab.Email == model.TEmail && Mem_Tab.PWD == model.TPWD
                            select new
                            {
                                model.TEmail,
                                model.TName
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["Email"] = user.FirstOrDefault().TEmail;
                    Session["Name"] = user.FirstOrDefault().TName;
                    //return View("Create", "Resumes");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return RedirectToAction("Create", "Resumes");
        }

        // GET: Trainer_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer_Details trainer_Details = db.Trainer_Details.Find(id);
            if (trainer_Details == null)
            {
                return HttpNotFound();
            }
            return View(trainer_Details);
        }

        // POST: Trainer_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TId,TName,TDOB,TDateofjoin,TSalary,TQualification,TSchedule,TEmail,TPWD")] Trainer_Details trainer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer_Details);
        }

        // GET: Trainer_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer_Details trainer_Details = db.Trainer_Details.Find(id);
            if (trainer_Details == null)
            {
                return HttpNotFound();
            }
            return View(trainer_Details);
        }

        // POST: Trainer_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer_Details trainer_Details = db.Trainer_Details.Find(id);
            db.Trainer_Details.Remove(trainer_Details);
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
