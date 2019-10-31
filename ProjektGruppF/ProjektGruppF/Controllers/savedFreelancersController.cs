using ProjektGruppF.Models;
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
            savedFreelancersM sf = new savedFreelancersM();
            return View(sf.SavefreeMList());
        }
    }
}