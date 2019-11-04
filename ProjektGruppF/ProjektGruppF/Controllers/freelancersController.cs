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
        private ProjektGruppFEntities1 db = new ProjektGruppFEntities1();

        // GET: freelancers
        public ActionResult Index()
        {
            var freelancer = db.freelancer.Include(f => f.cv);
            return View(freelancer);
        }

        // GET: freelancers/Details/5
        public ActionResult Start(int? id=8)
        {

            ViewBag.skill = new SelectList(db.skill, "skill_id", "name");
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
        public ActionResult CV(int? id = 7)
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

        // GET: freelancers/Create
        public ActionResult Create()
        {
            ViewBag.cv_id = new SelectList(db.cv, "cv_id", "nationality");
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

            ViewBag.cv_id = new SelectList(db.cv, "cv_id", "nationality", freelancer.cv_id);
            return View(freelancer);
        }

        // GET: freelancers/Edit/5
        public ActionResult Edit(int? id=8)
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
    }
}
