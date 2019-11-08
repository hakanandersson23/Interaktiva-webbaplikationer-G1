using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ProjektGruppF.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjektGruppF.ViewModels
{
    public class Freelancer
    {
        public int Freelancer_id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public int? Phonenumber { get; set; }
        public string Email { get; set; }
        public string Employername { get; set; }
        public string Jobtitle { get; set; }
        public string Role { get; set; }
        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public System.DateTime? Startdate { get; set; }
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public System.DateTime? Enddate { get; set; }
        public string PersonalNote { get; set; }
        public string MainAbilityName { get; set; }

        public virtual int Cv_id { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime Birthday { get; set; }
        public int Age { get; set; }
        //public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public string Drivers_license { get; set; }
        public string CoverLetter { get; set; }
        public System.DateTime Registration_date { get; set; }
        //public DateTime Registration_date { get; set; }

        public string NameOfEducationalInstitution { get; set; }


        public string Education { get; set; } // ge problem annars

        public int StudyYears { get; set; }


        public string Work_experience { get; set; }


        public string Expertise { get; set; }


        public string main_abilities { get; set; }


        public string Skill { get; set; }

        //[ForeignKey("language")]
        public string Language { get; set; }

        public List<work_experience> Work_Experience_List { get; set; }
        public List<skill> SkillList { get; set; }
        public List<expertise> ExpertiseList { get; set; }
        public List<education> EducationList { get; set; }
        public List<Main_abilities> MainAbilitiesList { get; set; }
        public List<language> FreelancerLanguageList { get; set; }

        //public List<language> LanguageList { get; set; } //liger nu in cv.cs
        //public cv Cv { get; set; }

        //public IEnumerable<SelectListItem> AllLanguages { get; set; }
        //private List<int> languageList;
        //public language language { get; set; }
        //public List<int> TotalLanguageList
        //{
        //    get
        //    {
        //        if (languageList == null)
        //        {

        //            //listOfCourses = Program.Course.Select(m => m.Id).ToList();
        //            //cv Cv = new cv();

        //            //languageList = cv.language.Select(m => m.language_id).ToList();
        //            languageList = Cv.language.Select(m => m.).ToList();
        //            //languageList = Cv.language.Select(o => new SelectListItem { Text = o., Value = o.Id.ToString() });

        //        }
        //        return languageList;
        //    }
        //    set { languageList = value; }
        //}
        //public string languageName { get; set; }
        //public int language_id { get; set; }
    }
}