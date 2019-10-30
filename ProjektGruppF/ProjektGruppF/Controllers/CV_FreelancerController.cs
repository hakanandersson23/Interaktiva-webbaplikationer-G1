using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGruppF.Models;

namespace ProjektGruppF.Controllers
{
    public class CV_FreelancerController : Controller
    {
        // GET: CV_Freelancer behövs inte
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            cv cvModel = new cv();
            return View(cvModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(cv cvModel) //sparar värden i tabell cv
        {
            using(ProjektGruppFEntities dbModel = new ProjektGruppFEntities())
            {
                dbModel.cv.Add(cvModel);  //cvs??
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "CV Registration succesfull.";
            return View("AddOrEdit", new cv()); //create new user
        }
    }
}