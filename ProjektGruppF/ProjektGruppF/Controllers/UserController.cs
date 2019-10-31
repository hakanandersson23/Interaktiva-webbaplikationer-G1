using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}