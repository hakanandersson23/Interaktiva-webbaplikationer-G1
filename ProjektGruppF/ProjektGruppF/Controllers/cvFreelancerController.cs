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
    public class cvFreelancerController : Controller
    {
        private ProjektGruppFEntities1 db = new ProjektGruppFEntities1();

        // GET: cvFreelancer
        public ActionResult Index()
        {
            return View(db.cv.ToList());
        }


        
        //public ActionResult Index()
        //{
        //    CvFreelancerOperations cvfO = new CvFreelancerOperations();

        //    return View(cvfO.LanguageList());
        //}
        //// GET: cvFreelancer/Details/5
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
         
            // GET: cvFreelancer/Create
            public ActionResult Create()
        {
           
            return View();
        }

        public ActionResult Conformation()
        {

            return View();
        }
        //private DateTime _returndate = DateTime.MinValue;
        //public DateTime registration_date
        //{
        //    get { return (_returndate == DateTime.MinValue) ? DateTime.Now : _returndate; }
        //    set { _returndate = value; }
        //}


        // POST: cvFreelancer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "birthday,nationality,drivers_license,registration_date")] cv cv)
        {
            

            if (ModelState.IsValid)
            {
               
                db.cv.Add(cv);
                db.SaveChanges();             
                ViewBag.SuccessMessage = "Registration Successful.";
                return RedirectToAction("Index");//conformation?


            }

            return View(cv);
        }
        
        public ActionResult Create([Bind(Include = "language")] language language)
        {

            CvFreelancerOperations fcv = new CvFreelancerOperations();
            
            if (ModelState.IsValid)
            {

                List<string> languages = new List<string>();
                languages.Add("Swedish");
                languages.Add("English");
                languages.Add("Spanish");
                languages.Add("French");
                SelectList languagesList = new SelectList(languages);
                ViewData["languagesList"] = languagesList;
                db.language.Add(language);
                db.SaveChanges();
                //ViewBag.SuccessMessage = "Registration Successful.";
                return RedirectToAction("Index");//conformation?


            }

            return View(language);
        }
       

        // GET: cvFreelancer/Edit/5


        //    //inte färdigt 
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

        //    var FreelancerViewModel = new Freelancer
        //    { Cv = db.cv.Include(i => i.Language).First(i => i.language_id == id), };//skapade         public int? language_id { get; internal set; } i cv.cs


        //    if (FreelancerViewModel.Cv == null)
        //        return HttpNotFound();


        //    var languagesList = db.language.ToList();
        //    FreelancerViewModel.AllLanguages = languagesList.Select(o => new SelectListItem { Text = o.name, Value = o.language_id.ToString() });

        //    //ViewBag.EmployerID = new SelectList(db.freelancer, "Id", "Name", FreelancerViewModel.cv.freelancer_id);
        //    ViewBag.FreelancerID = new SelectList(db.freelancer, "Id", "Name", FreelancerViewModel.Cv.freelancer);


        //    return View(FreelancerViewModel);
        //}

        // POST: cvFreelancer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cv_id,birthday,nationality,drivers_license,registration_date")] cv cv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cv);
        }

        
        // GET: cvFreelancer/Delete/5
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

        // POST: cvFreelancer/Delete/5
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
