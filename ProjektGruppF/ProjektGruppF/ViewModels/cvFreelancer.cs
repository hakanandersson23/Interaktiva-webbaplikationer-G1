using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGruppF.ViewModels
{
    public class cvFreelancer
    {

        public virtual int Cv_id { get; set; }
        public System.DateTime Birthday { get; set; }
        //public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public string Drivers_license { get; set; }

        public System.DateTime Registration_date { get; set; }
        //public DateTime Registration_date { get; set; }

        public string NameOfEducationalInstitution { get; set; }

       
        public string Education { get; set; } // ge problem annars

        
        public string Work_experience { get; set; }

        
        public string Expertise { get; set; }

        
        public string main_abilities { get; set; }

       
        public string Skill { get; set; }

        
        public string Language { get; set; }
    }
}