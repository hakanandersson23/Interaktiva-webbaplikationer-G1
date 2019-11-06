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
        public ActionResult Index()
        {
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
        }
        public JsonResult GetExpertises(string skills)
        {
            List<string> expertises = new List<string>();
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
    }
}