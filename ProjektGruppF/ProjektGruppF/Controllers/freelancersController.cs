using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektGruppF.Models;

namespace ProjektGruppF.Controllers
{
    public class freelancersController : Controller

        //TESTLinda
    {
        FreelancerCardOperations fc = new FreelancerCardOperations();

        private ProjektGruppFEntities1 db = new ProjektGruppFEntities1();

            savedFreelancersOperations sOP = new savedFreelancersOperations();
        // GET: freelancers
        public ActionResult Index()
        {
            var freelancer = db.freelancer.Include(f => f.cv);
            return View(freelancer);
        }
        public ActionResult skills_Expertiser()
        {
            List<string> skills = new List<string>();
            skills.Add("All Skills");
            skills.Add("Programming");
            skills.Add("Web developing");
            skills.Add("Databases");
            skills.Add("Mobile applications developing");
            SelectList skillsList = new SelectList(skills);
            ViewData["skillsList"] = skillsList;
            return View(sOP.AllFreelancers());

        }
        [HttpPost]
        public ActionResult skills_ExpertiserCreate([Bind(Include = "expertise_id,cv_id")] expertise_cv expertise)
        {
            if (ModelState.IsValid)
            {
                db.expertise_cv.Add(expertise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sOP.AllFreelancers());

        }

        // GET: freelancers/Details/5
        public ActionResult Start(int? id=9)
        {
            

            //ViewBag.skill = new SelectList(db.skill, "skill_id", "name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            freelancer freelancer = db.freelancer.Find(id);
            if (freelancer == null)
            {
                return HttpNotFound();
            }
            return View(freelancer);
        }
        public ActionResult CV(int freelancer_id=9, int cv_id=7)
        {
            if (freelancer_id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerCardOperations flc = new FreelancerCardOperations();

            if (cv_id == 0)
            {
                return HttpNotFound();
            }
            return View(flc.ViewFreelancer(freelancer_id, cv_id));
        }

        // GET: freelancers/Create
        public ActionResult Create()
        {
           // ViewBag.cv_id = new SelectList(db.cv, "cv_id", "nationality");
            return View();
        }

        // POST: freelancers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "freelancer_id,firstname,lastname,adress,phonenumber,email,cv_id")] freelancer freelancer)
        {
            if (ModelState.IsValid)
            {
                db.freelancer.Add(freelancer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.cv_id = new SelectList(db.cv, "cv_id", "nationality", freelancer.cv_id);
            return View(freelancer);
        }

        // GET: freelancers/Edit/5
        public ActionResult Edit(int? id=11)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            freelancer freelancer = db.freelancer.Find(id);
            if (freelancer == null)
            {
                return HttpNotFound();
            }
            ViewBag.cv_id = new SelectList(db.cv, "cv_id", "nationality", freelancer.cv_id);
            return View(freelancer);
        }

        // POST: freelancers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "freelancer_id,firstname,lastname,adress,phonenumber,email,PersonalLetter")] freelancer freelancer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freelancer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Start");
            }
            ViewBag.cv_id = new SelectList(db.cv, "cv_id", "nationality", freelancer.cv_id);
            return View(freelancer);
        }

        // GET: freelancers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            freelancer freelancer = db.freelancer.Find(id);
            if (freelancer == null)
            {
                return HttpNotFound();
            }
            return View(freelancer);
        }

        // POST: freelancers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            freelancer freelancer = db.freelancer.Find(id);
            db.freelancer.Remove(freelancer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetExpertises(string skills)
        {
            List<string> expertises = new List<string>();
            List<string> s = new List<string>();
            s.Add(skills);
            fc.UppdateSkill_cv(12, s);
            switch (skills)
            {
                case "Programming":
                    expertises.Add("C#");
                    expertises.Add("Java");
                    expertises.Add("Python");
                    break;
                case "Web developing":
                    expertises.Add("HTML");
                    expertises.Add("CSS");
                    expertises.Add("Javascript");
                    expertises.Add("JQuery");
                    expertises.Add("PHP");
                    break;
                case "Databases":
                    expertises.Add("Postgres");
                    expertises.Add("Oracle");
                    expertises.Add("MySQL");
                    break;
                case "Mobile applications developing":
                    expertises.Add("Android");
                    expertises.Add("IOS");
                    break;
            }
            return Json(expertises);
        }
    }
}
