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
    public class CV_Controller : Controller
    {
        private ProjektGruppFEntities1 db = new ProjektGruppFEntities1();

        // GET: CV_
        //public ActionResult Index()
        //{
        //    return View(db.cv.ToList());
        //}

        public ActionResult Index()
        {

            return View(db.cv.ToList());
        }

        public ActionResult Index()
        {
            CvFreelancerOperations cvfO = new CvFreelancerOperations();
            
            return View(cvfO.FreelancercardVMList());
        }

        // GET: CV_/Details/5
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

        // GET: CV_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CV_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cv_id,birthday,nationality,drivers_license,registration_date,profil")] cv cv)

        {
            if (ModelState.IsValid)
            {
                db.cv.Add(cv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cv);
        }

        // GET: CV_/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    cv cv = db.cv.Find(id);
        //    if (cv == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cv);
        //}

        public ActionResult Edit(int? id)
        {
            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

            var languageViewModel = new language
            { Cv = db.cv.Include(i => i.Language).First(i => i.cv_id == id), };

            if (languageViewModel.Cv == null)
                return HttpNotFound();


            var languagesList = db.language.ToList();
            languageViewModel.AllLanguages = languagesList.Select(o => new SelectListItem { Text = o.name, Value = o.language_id.ToString() });

            ViewBag.EmployerID = new SelectList(db.freelancer, "Id", "Name", languageViewModel.Cv.freelancer_id);

            return View(languageViewModel);
        }


        // POST: CV_/Edit/5
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

        // GET: CV_/Delete/5
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

        // POST: CV_/Delete/5
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
