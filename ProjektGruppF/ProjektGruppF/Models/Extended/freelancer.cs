using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjektGruppF.Models
{
    public partial class freelancer
    {


    }

    public class freelancerMetadatad
    {
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="Ooops, you forgot to enter you name!")]
        public string firstname { get; set; }
    }
}