using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;

namespace ProjektGruppF.Controllers
{
    public class CVversion3Controller : Controller
    {
            FreelancerCardOperations fc = new FreelancerCardOperations();
        private ProjektGruppFEntities1 db = new ProjektGruppFEntities1();

        // GET: CVversion3
        public ActionResult Index()
        {
            return View(db.cv.ToList());
        }

        //public ActionResult Index(string language)
        //{
        //    CvFreelancerOperations cvfO = new CvFreelancerOperations();

        //    return View(cvfO.LanguageList());
        //}

        // GET: CVversion3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cv cv = db.cv.Find(id);
            if (cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        // GET: CVversion3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CVversion3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cv_id,birthday,nationality,drivers_license,registration_date,profil")] ViewModels.Freelancer freelancer)
        {
            cv cv = new cv();
            language language = new language();
            if (ModelState.IsValid)
            {
                db.cv.Add(cv);
                //List<string> languages = new List<string>();
                //languages.Add("Swedish");
                //languages.Add("English");
                //languages.Add("Spanish");
                //languages.Add("French");
                //SelectList languagesList = new SelectList(languages);
                //ViewData["languagesList"] = languagesList;
                //db.language.Add(language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(freelancer);
        }
        
        // GET: CVversion3/Edit/5
        public ActionResult Edit(int? id=7)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cv cv = db.cv.Find(id);
            if (cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

        //    var FreelancerViewModel = new ViewModels.Freelancer
        //    { Cv = db.cv.Include(i => i.Language).First(i => i.language_id == id), };//skapade         public int? language_id { get; internal set; } i cv.cs


        //    if (FreelancerViewModel.Cv == null)
        //        return HttpNotFound();


        //    var languagesList = db.language.ToList();
        //    FreelancerViewModel.AllLanguages = languagesList.Select(o => new SelectListItem { Text = o.name, Value = o.language_id.ToString() });

        //    //ViewBag.EmployerID = new SelectList(db.freelancer, "Id", "Name", FreelancerViewModel.cv.freelancer_id);
        //    ViewBag.FreelancerID = new SelectList(db.freelancer, "Id", "Name", FreelancerViewModel.Cv.freelancer);


        //    return View(FreelancerViewModel);
        //}

        // POST: CVversion3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cv_id,birthday,nationality,drivers_license,registration_date,profil")] cv cv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cv);
        }

        public ActionResult EditEducation(int id =2)
        {
            education ed = db.education.Find(id);
            return View(ed);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEducation([Bind(Include = "education_id,education_name,university_name,study_years")] education ed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ed).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(ed);
        }
        //public ActionResult EditMainAbilities()
        //{

        //   // Main_abilities ma = db.Main_abilities.Find(id);
        //    return View(fc.freeMainAbilities(9,7));
        //}
        //[HttpPost]
        //public ActionResult EditMainAbilities([Bind(Include = "main_abilities_id,name")] Freelancer ma)
        //{
        //    ma = fc.freeMainAbilities(9, 7);
        //    //FreelancerCardOperations fc = new FreelancerCardOperations();
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(ma).State = EntityState.Modified;

        //        db.SaveChanges();
        //        return RedirectToAction("Edit");
        //    }
        //    return View(ma);
        //}
        public ActionResult EditMainAbilities(int id=2)
        {

             Main_abilities ma = db.Main_abilities.Find(id);
            return View(ma);
        }
        [HttpPost]
        public ActionResult EditMainAbilities([Bind(Include = "main_abilities_id,name")] Main_abilities ma)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(ma).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(ma);
        }
        public ActionResult EditWorkExperience(int id = 15)
        {

            work_experience ma = db.work_experience.Find(id);
            return View(ma);
        }
        [HttpPost]
        public ActionResult EditWorkExperience([Bind(Include = "work_experience_id,employer_name,job_title,role,start_date,end_date,")] work_experience we)
        {

            if (ModelState.IsValid)
            {
                db.Entry(we).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(we);
        }



        public ActionResult MainAbilitiesL()
        {

            FreelancerCardOperations fc = new FreelancerCardOperations();
            //Main_abilities ma = db.Main_abilities.Find(id);
            return View(fc.freeMainAbilities(9,7));
        }
        public ActionResult EditLanguage(int id = 1)
        {
            language la = db.language.Find(id);
            return View(la);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLanguage([Bind(Include = "language_id,name")] language la)
        {
            if (ModelState.IsValid)
            {
                db.Entry(la).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(la);
        }
        // GET: CVversion3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cv cv = db.cv.Find(id);
            if (cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        // POST: CVversion3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cv cv = db.cv.Find(id);
            db.cv.Remove(cv);
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
    }
}
