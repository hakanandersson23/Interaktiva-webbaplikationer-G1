using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ProjektGruppF.Models;
using System.Web.Mvc;

namespace ProjektGruppF.ViewModels
{
    public class cvFreelancer
    {

        public virtual int freelancer_id { get;set; }
      public int Freelancer_id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public int? Phonenumber { get; set; }
        public string Email { get; set; }
        public string Employername { get; set; }
        public string Jobtitle { get; set; }
        public string Role { get; set; }
        public System.DateTime? Startdate { get; set; }
        public System.DateTime? Enddate { get; set; }

        public virtual int Cv_id { get; set; }
        public System.DateTime Birthday { get; set; }
        //public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public string Drivers_license { get; set; }
        public string Profil { get; set; }
        public System.DateTime Registration_date { get; set; }
        //public DateTime Registration_date { get; set; }

        public string NameOfEducationalInstitution { get; set; }

       
        public string Education { get; set; } // ge problem annars

        //public IEnumerable<SelectListItem> NameOfEducationalInstitution { get; set; }

        //private List<int> listOfSchoolnames;
        //public List<int> ListOfSchoolNames
        //{ get { if (ListOfSchoolNames == null)
        //        { ListOfSchoolNames = Education.university_name.Select(m => m.Id).ToList(); }
        //        return ListOfSchoolNames; }
        //    set { ListOfSchoolNames = value; }
        //}
    

        public int StudyYears { get; set; }
 
        
        public string Work_experience { get; set; }

       
        public string Expertise { get; set; }

        
        public string main_abilities { get; set; }

       
        public string Skill { get; set; }
       
        //[ForeignKey("language")]
       public string Language { get; set; }

        public cv Cv { get; set; }
        public IEnumerable<SelectListItem> AllLanguages { get; set; }

        private List<int> listOflanguages;
        //public List<int> ListOfLanguages
        //{
        //    get
        //    {
        //        if (ListOfLanguages == null)
        //        { ListOfLanguages = Cv.language; }
        //        return ListOfLanguages;
        //    }
        //    set { ListOfLanguages = value; }
        //}

    }
}