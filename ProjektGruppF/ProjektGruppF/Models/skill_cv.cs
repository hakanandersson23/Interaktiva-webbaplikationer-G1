//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektGruppF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class skill_cv
    {
        public int skill_cv_id { get; set; }
        public int skill_id { get; set; }
        public int cv_id { get; set; }
    
        public virtual cv cv { get; set; }
        public virtual skill skill { get; set; }
    }
}
