using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;

namespace ProjektGruppF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
            return View();  
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}