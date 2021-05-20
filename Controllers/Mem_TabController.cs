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
    public class Mem_TabController : Controller
    {
        private Database1Entities2 db = new Database1Entities2();

        // GET: Mem_Tab
        

        // GET: Mem_Tab/Details/5
       

        // GET: Mem_Tab/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
      
        // POST: Mem_Tab/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address,Mobile_NO,Age,Email,PWD")] Mem_Tab mem_Tab)
        {
            if (ModelState.IsValid)
            {
                db.Mem_Tab.Add(mem_Tab);
                db.SaveChanges();
            //    return RedirectToAction("Index");
            }

            return View("Login");
        }

        // GET: Mem_Tab/Edit/5
        [HttpPost]
    //    [ValidateAntiForgeryToken]
        public ActionResult Login(Mem_Tab model)
        {
            if(ModelState.IsValid)
            {
                Database1Entities2 db = new Database1Entities2();
                var user = (from Mem_Tab in db.Mem_Tab
                            where Mem_Tab.Email == model.Email && Mem_Tab.PWD == model.PWD
                            select new
                            {
                                model.Email,
                                model.Name
                            }).ToList();
                if(user.FirstOrDefault() !=null)
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
            return RedirectToAction("Create","Resumes");  
        }

        public ActionResult ResumeBuilding()
        {
            return View();
        }

    }
}
