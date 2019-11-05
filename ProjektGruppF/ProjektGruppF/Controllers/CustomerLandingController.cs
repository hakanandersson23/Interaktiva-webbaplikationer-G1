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

      
        public ActionResult FreelancerProfile(int freelancer_id, int cv_id)
        {
            FreelancerCardOperations flc = new FreelancerCardOperations();
            ViewBag.Message = freelancer_id.ToString();
            return View(flc.ViewFreelancer(freelancer_id, cv_id));
        }
    }
}