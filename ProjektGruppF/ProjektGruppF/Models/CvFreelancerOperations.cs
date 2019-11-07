using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGruppF.Models
{
    public class CvFreelancerOperations
    {

        //public List<language> languageList()
        //{
        //    ProjektGruppFEntities1 p = new ProjektGruppFEntities1();
        //    List<language> languagesList = new List<language>();
        //    var språklist = (from l_table in p.language

        //                     select new
        //                     {
        //                         l_table.language_id,
        //                         l_table.name,

        //                     }).ToList();
        //    foreach (var item in språklist)
        //    {

        //        language l = new language();
        //        l.language_id = item.language_id;
        //        l.name = item.name;

        //        languagesList.Add(l);
        //    }

        //    return languagesList;

        //public List<ViewModels.Freelancer> LanguageList() //kopie stor L
        //{
        //    ProjektGruppFEntities1 p = new ProjektGruppFEntities1();
        //    List<ViewModels.Freelancer> TotalLanguageList = new List<ViewModels.Freelancer>();
        //    var språklist = (from l_table in p.language

        //                     select new
        //                     {
        //                         l_table.language_id,
        //                         l_table.name,

        //                     }).ToList();
        //    foreach (var item in språklist)
        //    {

        //        ViewModels.Freelancer l = new ViewModels.Freelancer();
        //        l.language_id = item.language_id;
        //        l.languageName = item.name;

        //        TotalLanguageList.Add(l);
        //    }

        //    return TotalLanguageList;

        //public List<cv> LanguageList()
        //{
        //    ProjektGruppFEntities1 p = new ProjektGruppFEntities1();
        //    List<cv> TotalLanguageList = new List<cv>();
        //    var språklist = (from l_table in p.language

        //                     select new
        //                     {
        //                         l_table.language_id,
        //                         l_table.name,

        //                     }).ToList();
        //    foreach (var item in språklist)
        //    {

        //        cv l = new cv();
        //        l.language_id = item.language_id;
        //        l.name = item.name;

        //        TotalLanguageList.Add(l);
        //    }

        //    return TotalLanguageList;
        //}

        ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
        public void UppdateLanguage_cv(int id, List<string> name)
        {
            int language_ID = GetLanguageID(id);
            int nr = 0;
            List<string> L = new List<string>();

            L = name;
            foreach (var item in L)
            {
                if (item == "Swedish")
                {
                    nr = 1;
                }
                else if (item == "English")
                {
                    nr = 2;
                }
                else if (item == "Spanish")
                {
                    nr = 3;
                }
                else if (item == "French")
                {
                    nr = 4;
                }
            }

            var query =
               from sc in pgfe.language_cv
               where sc.language_id == language_ID && sc.cv_id == id
               select sc;

            foreach (language_cv sc in query)
            {
                if (sc.language_id == nr)
                {
                    sc.language_id = nr;
                }
                else
                {
                    sc.language_id = nr;

                }
            }
            pgfe.SaveChanges();

        }

        public int GetLanguageID(int cv_id)
        {
            int nr = 0;
            var query =
                     (from sc in pgfe.language_cv
                      where sc.cv_id == cv_id
                      select new
                      {
                          sc.language_id
                      }).FirstOrDefault();
            nr = query.language_id;

            return nr;

        }

        public void UppdateMainAbilities_cv(int id, List<string> name)
        {
            int mainAbilities_ID = GetMainAbilitiesID(id);
            int nr = 0;
            List<string> L = new List<string>();

            L = name;
            foreach (var item in L)
            {
                if (item == "Teamplayer")
                {
                    nr = 1;
                }
                else if (item == "Effective")
                {
                    nr = 2;
                }
                else if (item == "Quick learner")
                {
                    nr = 3;
                }
                else if (item == "Positive")
                {
                    nr = 4;
                }
            }

            var query =
               from sc in pgfe.main_abilities_cv
               where sc.main_abilities_id == mainAbilities_ID && sc.cv_id == id
               select sc;

            foreach (main_abilities_cv sc in query)
            {
                if (sc.main_abilities_id == nr)
                {
                    sc.main_abilities_id = nr;
                }
                else
                {
                    sc.main_abilities_id = nr;

                }
            }
            pgfe.SaveChanges();

        }
        public int GetMainAbilitiesID(int cv_id)
        {
            int nr = 0;
            var query =
                     (from sc in pgfe.main_abilities_cv
                      where sc.cv_id == cv_id
                      select new
                      {
                          sc.main_abilities_id
                      }).FirstOrDefault();
            nr = query.main_abilities_id;

            return nr;

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