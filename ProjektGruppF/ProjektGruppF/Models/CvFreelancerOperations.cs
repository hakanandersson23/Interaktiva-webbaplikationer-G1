using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGruppF.Models
{
    public class CvFreelancerOperations
    {


        public List<language> languageList()
        {
            ProjektGruppFEntities1 p = new ProjektGruppFEntities1();
            List<language> languagesList = new List<language>();
            var språklist = (from l_table in p.language

                             select new
                             {
                                 l_table.language_id,
                                 l_table.name,

                             }).ToList();
            foreach (var item in språklist)
            {

                language l = new language();
                l.language_id = item.language_id;
                l.name = item.name;

                languagesList.Add(l);
            }

            return languagesList;
        }
        //public void AddCv(cv cv)

        ////trycatch

        //{
        //    cv cvModel = new cv();

        //    using (ProjektGruppFEntities dbModel = new ProjektGruppFEntities())
        //    {


        //        {
        //            dbModel.cv.Add(cvModel);  
        //            dbModel.SaveChanges();

        //        }
        //    }
        //}

        //[HttpGet]
        //public ActionResult AddOrEdit(int id = 0)
        //{
        //    cv cvModel = new cv();
        //    return View(cvModel);
        //}

        // [HttpPost]
        //    public ActionResult AddOrEdit(cv cvModel) //sparar värden i tabell cv
        //    {
        //        using(ProjektGruppFEntities dbModel = new ProjektGruppFEntities())
        //        {
        //            dbModel.cv.Add(cvModel);  //cvs??
        //            dbModel.SaveChanges();
        //        }
        //        ModelState.Clear();
        //        ViewBag.SuccesMessage = "CV Registration succesfull.";
        //        return View("AddOrEdit", new cv()); //create new user
        //    }
    }

} 