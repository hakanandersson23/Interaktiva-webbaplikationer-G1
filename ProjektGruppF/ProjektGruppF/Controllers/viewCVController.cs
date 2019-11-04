using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;
using System.Data.Entity;

namespace ProjektGruppF.Controllers
{
    public class viewCVController : Controller
    {
        // GET: viewCV
        public ActionResult Index(int? cv_id)
        {
            ProjektGruppFEntities1 pg = new ProjektGruppFEntities1();
            ViewCVOperations vcv = new ViewCVOperations();

            cv cv = pg.cv.Find(cv_id);

            return View(vcv.CVFreelancer(cv));
        }
    }
}