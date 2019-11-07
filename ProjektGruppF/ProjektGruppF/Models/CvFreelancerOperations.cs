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

        public List<cv> LanguageList()
        {
            ProjektGruppFEntities1 p = new ProjektGruppFEntities1();
            List<cv> TotalLanguageList = new List<cv>();
            var språklist = (from l_table in p.language

                             select new
                             {
                                 l_table.language_id,
                                 l_table.name,

                             }).ToList();
            foreach (var item in språklist)
            {

                cv l = new cv();
                l.language_id = item.language_id;
                l.name = item.name;

                TotalLanguageList.Add(l);
            }

            return TotalLanguageList;
        }

        ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
        public void UppdateSkill_cv(int id, List<string> name)
        {
            int skill_ID = GetLanguageID(id);
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
               from sc in pgfe.laguage_cv
               where sc.skill_id == skill_ID && sc.cv_id == id
               select sc;

            foreach (skill_cv sc in query)
            {
                if (sc.skill_id == nr)
                {
                    sc.skill_id = nr;
                }
                else
                {
                    sc.skill_id = nr;

                }
            }
            pgfe.SaveChanges();
            //int nr = 2;
            //ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
            //var uppdateSkill_cv = from s_c in pgfe.skill_cv
            //                      join s in pgfe.skill on s_c.cv_id
            //                      equals s.skill_id
            //                      where s_c.cv_id == id
            //                      where s.skill_id == 1
            //                      select s_c;

            //foreach (var item in uppdateSkill_cv)
            //{

            //    item.cv_id = id;
            //    item.skill_id = nr;

            //}
            //pgfe.SaveChanges();
            //foreach (var skill in uppdateSkill_cv)
            //{
            //    foreach (var names in name)
            //    {
            //        skill.name = names;
            //    }
            //}
            //pgfe.SaveChanges();dsdsa



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