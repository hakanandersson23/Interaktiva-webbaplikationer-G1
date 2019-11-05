using ProjektGruppF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGruppF.ViewModels
{
    public class Language
    {

        public cv Cv { get; set; }
        public IEnumerable<SelectListItem> AllLanguages { get; set; }

        private List<int> listOflanguages;
        //public List<int> ListOfLanguages
        //{
        //    //get
        //    //{
        //    //    if (ListOfLanguages == null)
        //    //    //{ ListOfLanguages = Cv.Language.Select(m => m.Id).ToList(); }
        //    //    return ListOfLanguages;
        //    //}
        //    //set { ListOfLanguages = value; }
        //}

    }
}
   