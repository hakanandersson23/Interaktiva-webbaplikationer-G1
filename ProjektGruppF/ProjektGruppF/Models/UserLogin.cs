﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjektGruppF.Models
{
    public class UserLogin
    {
        [Display(Name ="Email")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email is needed.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is needed.")]

        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }



    }
}