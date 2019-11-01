﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGruppF.Models;

namespace ProjektGruppF.Controllers
{
    public class freelancerController : Controller
    {
        // GET: freelancer
        public ActionResult AddOrEdit(int id =0)
        {
            freelancer userModel = new freelancer();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(freelancer free)
        {
            using (ProjektGruppFEntities f = new ProjektGruppFEntities())
            {

                if (f.freelancer.Any(x => x.firstname == free.firstname))
                {

                    ViewBag.DuplicateMessage = "The user already exists.";
                    return View("AddOrEdit", free);
                }
                f.freelancer.Add(free);
                f.SaveChanges();
            };
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit",new freelancer());

            


        }

        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
       
    }
}