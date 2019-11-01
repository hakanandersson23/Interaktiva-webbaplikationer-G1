using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGruppF.Models;

namespace ProjektGruppF.Controllers
{
    public class UserController : Controller
    {
        // GET: User

            [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration ([Bind]freelancer free)
        {

            bool status = false;
            string message = "";

          
                #region Email exists
                var isExisting = isEmailExisting(free.email);
                if (isExisting)
                {
                    ModelState.AddModelError("EmailExists", "Email already exists");
                    return View(free); 
                }
                #endregion

                using (ProjektGruppFEntities dc = new ProjektGruppFEntities())
                {
                    dc.freelancer.Add(free);
                    dc.SaveChanges();
                }


            
         
            ViewBag.Message = message;
            ViewBag.Status = status;


            return View(free);
        }

        [NonAction]
        public bool isEmailExisting(string emailID)
        {
            using (ProjektGruppFEntities dc = new ProjektGruppFEntities())
            {
                var v = dc.freelancer.Where(a => a.email == emailID).FirstOrDefault();
                return v != null; 
            }
        }


    }
}