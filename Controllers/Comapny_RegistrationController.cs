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
    public class Comapny_RegistrationController : Controller
    {
        private Database1Entities2 db = new Database1Entities2();

        // GET: Comapny_Registration
        public ActionResult Index()
        {
            return View(db.Comapny_Registration.ToList());
        }

        // GET: Comapny_Registration/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comapny_Registration comapny_Registration = db.Comapny_Registration.Find(id);
            if (comapny_Registration == null)
            {
                return HttpNotFound();
            }
            return View(comapny_Registration);
        }

        // GET: Comapny_Registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comapny_Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Certificate_Number,Phone_Number,Password,CPassword,City,Email")] Comapny_Registration comapny_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Comapny_Registration.Add(comapny_Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comapny_Registration);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //    [ValidateAntiForgeryToken]
        public ActionResult Login(Comapny_Registration model)
        {
            if (ModelState.IsValid)
            {
                Database1Entities1 db = new Database1Entities1();
                var user = (from CRD in db.Comapny_Registration
                            where CRD.Email == model.Email && CRD.Password == model.Password
                            select new
                            {
                                model.Email,
                                model.Name
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["Email"] = user.FirstOrDefault().Email;
                    Session["Name"] = user.FirstOrDefault().Name;
                    //return View("Create", "Resumes");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return RedirectToAction("Create", "Company_Details");
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
