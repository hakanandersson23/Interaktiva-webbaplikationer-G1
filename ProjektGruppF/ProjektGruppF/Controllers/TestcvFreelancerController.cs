using ProjektGruppF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGruppF.Controllers
{
    public class TestcvFreelancerController : Controller
    {
        // GET: TestcvFreelancer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Databaseexample()
        {
            ProjektGruppFEntities dbModel = new ProjektGruppFEntities();
            var getDrivers_licenseOptions = dbModel.cv.ToList();
            SelectList list = new SelectList(getDrivers_licenseOptions, "drivers_license");// alla parametrers van Cv?
            ViewBag.drivers_license = list;
            return View();
        }
    }
}