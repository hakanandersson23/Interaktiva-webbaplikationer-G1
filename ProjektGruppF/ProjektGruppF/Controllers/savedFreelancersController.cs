using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;
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
        ProjektGruppFEntities1 pg = new ProjektGruppFEntities1();
        savedFreelancersOperations sOP = new savedFreelancersOperations();
        public ActionResult Index()
        {
            return View(sOP.AllFreelancers());
        }
        public JsonResult GetExpertises()
        {
            return Json(pg.expertise.Select(e => new { ExpertiseName = e.name, ExpertiseID = e.expertise_id }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRanks(int? expertises)
        {
            var ranks = pg.rank_expertise.AsQueryable();

            if (expertises != null)
            {
                ranks = ranks.Where(r => r.rank_expertise_Id == expertises);
            }

            return Json(ranks.Select(r => new { RankName = r.name, RankID = r.rank_expertise_Id }), JsonRequestBehavior.AllowGet);

            /*var expertises = (from ex in pg.expertise
                              join excv in pg.expertise_cv on ex.expertise_id equals excv.expertise_id
                              join c in pg.cv on excv.cv_id equals c.cv_id
                              join s in pg.skill_cv on c.cv_id equals s.cv_id
                              join sk in pg.skill on s.skill_id equals sk.skill_id
                              where excv.cv_id == c.cv_id  
                              
                              select new
                              {
                                  sk.skill_id,
                                  sk.name,
                                  ex.expertise_id
                              }).AsQueryable();
            if (skills != null)
            {

            }*/
        }
    }
}