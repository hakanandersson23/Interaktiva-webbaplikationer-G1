using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGruppF.Controllers
{
    public class savedFreelancersController : Controller
    {
        FreelancerCardOperations fc = new FreelancerCardOperations();
        public ActionResult Index()
        {
            int cusID = 11;
            savedFreelancersOperations sfo = new savedFreelancersOperations();
            return View(sfo.CusSavedFree(cusID));
            /*
            savedFreelancersOperations sOP = new savedFreelancersOperations();
            List<string> skills = new List<string>();
            skills.Add("All Skills");
            skills.Add("Programming");
            skills.Add("Web developing");
            skills.Add("Databases");
            skills.Add("Mobile applications developing");
            SelectList skillsList = new SelectList(skills);
            ViewData["skillsList"] = skillsList;
            return View(sOP.AllFreelancers());
            */
        }
        public JsonResult GetExpertises(string skills)
        {
            List<string> expertises = new List<string>();
            List<string> s = new List<string>();
            s.Add(skills);
            fc.UppdateSkill_cv(12, s);
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
        public ActionResult DeleteFreelancer(int cusID, int freeID)
        {
            savedFreelancersOperations sfo = new savedFreelancersOperations();
            sfo.DeleteFreeFromCus(cusID, freeID);
            return RedirectToAction("Index");
        }
        public ActionResult SaveFreeToCus(int cusID, int freeID)
        {
            FreelancerCardOperations flc = new FreelancerCardOperations();
            flc.SavefreeToCus(cusID, freeID);
            return RedirectToAction("Index");
        }
    }
}