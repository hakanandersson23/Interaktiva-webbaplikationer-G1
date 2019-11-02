using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGruppF.Controllers
{
    public class CustomerLandingController : Controller
    {
        // GET: CustomerLanding


        public ActionResult Index()
        {
            FreelancerCardOperations flc = new FreelancerCardOperations();
            /*return View(flc.GetCards());*/
            return View(flc.FreelancercardVMList());
        }

        [HttpPost]
        public ActionResult Index(int user_id)
        {
            return View();
        }

      
        public ActionResult FreelancerProfile(int id)
        {
            ViewBag.Message = id.ToString();
            return View();
        }
    }
}