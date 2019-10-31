using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjektGruppF.Models;

namespace ProjektGruppF.ViewModels
{
    public class SavedFreelancersVM
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public int? Phonenumber { get; set; }
        public string Email { get; set; }
        public string Skillname { get; set; }
        public string Expertisename { get; set; }  
        public int ExpertiseRank { get; set; } 
    }
}