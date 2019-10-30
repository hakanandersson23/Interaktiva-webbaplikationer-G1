using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGruppF.ViewModels
{
    public class cvFreelancer
    {

        public virtual int cv_id { get; set; }
        //public System.DateTime birthday { get; set; }
        public DateTime birthday { get; set; }
        public string nationality { get; set; }
        public string drivers_license { get; set; }
        //public System.DateTime registration_date { get; set; }
        public DateTime registration_date { get; set; }
    }
}