using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
namespace WebApplication6.Controllers
{
    public class ViewjobController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();
        // GET: Viewjob
        public ActionResult Index()
        {

            return View(db.Post_Job.ToList());
        }



        [HttpPost]
        public ActionResult Apply(string Apply, FormCollection fc)
        {
            Class1 c = new Class1();
            int jobid = 2;
            Session["Email"] = "ra.@ra.com";
            string qry = "INSERT INTO Apply_Job VALUES('"+ Session["Email"] +"',"+ jobid+",'apply')";

           if( c.ins_up_del(qry)==true)
            {
                 return  Redirect("/Post_Job/Create");

            }
            else
            {
                return Redirect("/Viewjob/Index");
                
            }
        }

        [HttpPost]
        public ActionResult Next(string Next, FormCollection fc)
        {
            System.Speech.Synthesis.SpeechSynthesizer s = new System.Speech.Synthesis.SpeechSynthesizer();
            s.Speak("Hello welcome to my website");

          
            return Redirect("/Post_Job/Index");

        }


    }
}