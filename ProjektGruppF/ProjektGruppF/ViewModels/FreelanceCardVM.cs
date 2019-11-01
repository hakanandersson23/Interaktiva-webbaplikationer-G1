using ProjektGruppF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGruppF.ViewModels
{
    public class FreelanceCardVM
    {
        public string Skillname { get; set; }
        public int Skill_id { get; set; }
        public string Expertisename { get; set; }
        public int Expertise_id { get; set; }
        public int Freelancer_id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        /*
        public string Language { get; set; }
        public string Skill { get; set; }
        public string Expertise { get; set; }
        public int Rank { get; set; }
        */

    }
}