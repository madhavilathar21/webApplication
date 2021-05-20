using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using System.Speech.Synthesis;
//using System.Speech.Synthesis; 

namespace WebApplication6.Controllers
{
    public class Post_JobController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Post_Job
        public ActionResult Index()
        {
      
            Session["Email"] = "ramesh";
            return View(db.Post_Job.ToList());
           

          
        }
        [HttpPost]
        public ActionResult Next()
        {
          return RedirectToAction("Details", "Post_Job");
        }

        // GET: Post_Job/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post_Job post_Job = db.Post_Job.Find(id);
            if (post_Job == null)
            {
                return HttpNotFound();
            }
            
            return View(post_Job);
        }


        public ActionResult Apply()
        {
            Database1Entities1 db = new Database1Entities1();
            string aEmail = Convert.ToString(Session["Email"]);
            
            //var id = pj.Id;

            return View();
        }

        // GET: Post_Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post_Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comapany_Name,Job_Descripation,Requirements,Salary,Contact_Info,Email,Require_Qualification")] Post_Job post_Job)
        {
            if (ModelState.IsValid)
            {
                db.Post_Job.Add(post_Job);
                db.SaveChanges();
                
            }

            //return View(post_Job);
            return RedirectToAction("Details","Post_Job");
        }

        // GET: Post_Job/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post_Job post_Job = db.Post_Job.Find(id);
            if (post_Job == null)
            {
                return HttpNotFound();
            }
            return View(post_Job);
        }

        // POST: Post_Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comapany_Name,Job_Descripation,Requirements,Salary,Contact_Info,Email,Require_Qualification")] Post_Job post_Job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post_Job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post_Job);
        }

        // GET: Post_Job/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post_Job post_Job = db.Post_Job.Find(id);
            if (post_Job == null)
            {
                return HttpNotFound();
            }
            return View(post_Job);
        }

        // POST: Post_Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Post_Job post_Job = db.Post_Job.Find(id);
            db.Post_Job.Remove(post_Job);
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
