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
        // GET: savedFreelancers
        public ActionResult Index()
        {
            ProjektGruppFEntities1 pg = new ProjektGruppFEntities1();
            savedFreelancersOperations sOP = new savedFreelancersOperations();

            return View(sOP.AllFreelancers());
        }
    }
}