using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGruppF.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            // comment
            return View();
        }

        public ActionResult LoginView()
        {

            return View();
        }
    }
}