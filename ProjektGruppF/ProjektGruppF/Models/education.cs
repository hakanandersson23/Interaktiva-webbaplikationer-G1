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
    
    public partial class education
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public education()
        {
            this.cv = new HashSet<cv>();
        }
    
        public int education_id { get; set; }
        public string education_name { get; set; }
        public string university_name { get; set; }
        public int study_years { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cv> cv { get; set; }
    }
}