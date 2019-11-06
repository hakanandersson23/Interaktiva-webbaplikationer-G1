using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjektGruppF.Controllers
{
    public class savedFreelancersController : Controller
    {
        FreelancerCardOperations fk = new FreelancerCardOperations();
        private ProjektGruppFEntities1 db = new ProjektGruppFEntities1();

        public ActionResult Index()
        {
            savedFreelancersOperations sOP = new savedFreelancersOperations();
            List<string> skills = new List<string>();
            skills.Add("All Skills");
            skills.Add("Programming");
            skills.Add("Web developing");
            skills.Add("Databases");
            skills.Add("Mobile applications developing");
            skills.Add("Sesuna");
            SelectList skillsList = new SelectList(skills);
            ViewData["skillsList"] = skillsList;


            

            return View(sOP.AllFreelancers());

        }
        public JsonResult GetExpertises(string skills)
        {
            List<string> expertises = new List<string>();
                    List<string> s = new List<string>();
            s.Add(skills);
                    fk.UppdateSkill_cv(12, s);
            switch (skills)
            {
                case "Programming":
                    
                    expertises.Add("C#");
                    expertises.Add("Java");
                    expertises.Add("Python");
                    break;
                case "Web developing":
                    expertises.Add("HTML");
                    expertises.Add("CSS");
                    expertises.Add("Javascript");
                    expertises.Add("JQuery");
                    expertises.Add("PHP");
                    break;
                case "Databases":
                    expertises.Add("Postgres");
                    expertises.Add("Oracle");
                    expertises.Add("MySQL");
                    break;
                case "Mobile applications developing":
                    expertises.Add("Android");
                    expertises.Add("IOS");
                    break;
            }
            return Json(expertises);
        }
        public JsonResult GetRanks(string expertises)
        {
            List<int> ranks = new List<int>();
            switch (expertises)
            {
                case "C#":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "Java":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "Python":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "HTML":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "CSS":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "Javascript":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "JQuery":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "PHP":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "Postgres":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "Oracle":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "MySQL":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "Android":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
                case "IOS":
                    ranks.Add(5);
                    ranks.Add(4);
                    ranks.Add(3);
                    ranks.Add(2);
                    ranks.Add(1);
                    break;
            }

            return Json(ranks);
        }


        

        /*ProjektGruppFEntities1 pg = new ProjektGruppFEntities1();
        savedFreelancersOperations sOP = new savedFreelancersOperations();
        public ActionResult Index()
        {
            return View(sOP.AllFreelancers());
        }*/


    }
}