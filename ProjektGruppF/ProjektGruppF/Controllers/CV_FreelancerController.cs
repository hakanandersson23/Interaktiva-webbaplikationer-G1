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
        // GET: CV_Freelancer
        public ActionResult AddOrEdit(int id = 0)
        {
            cv cvModel = new cv();
            return View(cvModel);
        }
    }
}