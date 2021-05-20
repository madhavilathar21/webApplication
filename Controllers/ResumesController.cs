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
    public class ResumesController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Resumes
        //public ActionResult Index()
        //{
        //    //var resume = db.Resume.Include(r => r.Mem_Tab);
        //    //return View(resume.ToList());
        //}

        // GET: Resumes/Details/5
       
        public ActionResult Create()
        {
            ViewBag.Email = new SelectList(db.Mem_Tab, "Email", "Name");
            return View();
        }

        // POST: Resumes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FName,LName,Phone_No,Gender,Qulification,Address,City,Expertisy,Experince,ExtraSkills,Email")] Resume resume)
        {
            if (ModelState.IsValid)
            {
                db.Resumes.Add(resume);
              //  db.Resume.Add(resume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Email = new SelectList(db.Mem_Tab, "Email", "Name", resume.Email);
            return View(resume);
        }

        // GET: Resumes/Edit/5
    
    }
}
