using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjektGruppF.Models
{

    [MetadataType(typeof(freelancerMetadatad))]
    public partial class freelancer
    {
        public string confirmpassword { get; set; }


    }

    public class freelancerMetadatad
    {
        [Required(ErrorMessage = " oops, seems like you forgott to type your name. ")]
        public string firstname { get; set; }
        [Required(ErrorMessage = " oops, seems like you forgott to type your lastname. ")]


        public string lastname { get; set; }
        [Required(ErrorMessage = " oops, seems like you forgott to type your adress. ")]

        public string adress { get; set; }
        [Required(ErrorMessage = " oops, seems like you forgott to type your email. ")]

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = " oops, seems like you forgott to type your phone number.")]
        public Nullable<int> phonenumber { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = " oops, seems like you forgott to type your password.")]
        public string password { get; set; }

        [DataType(DataType.Password)]

        [Compare("password", ErrorMessage ="Passwords are not matching.")]
        public string confirmpassword { get; set; }
    }
}