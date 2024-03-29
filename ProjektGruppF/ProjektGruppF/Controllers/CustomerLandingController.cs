﻿using ProjektGruppF.Models;
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
            return View(flc.FreelancercardVMList());
        }
      
        public ActionResult FreelancerProfile(int freelancer_id, int cv_id)
        {
            FreelancerCardOperations flc = new FreelancerCardOperations();
            ViewBag.Message = freelancer_id.ToString();
            return View(flc.ViewFreelancer(freelancer_id, cv_id));
        }

        public ActionResult Testing(int cusID, int freeID)
        {
            FreelancerCardOperations flc = new FreelancerCardOperations();
            flc.SavefreeToCus(cusID, freeID);
            return RedirectToAction("Index");
        }
    }
}